const editProfileBtn = document.getElementById('edit-profile');
const showAppointmentsBtn = document.getElementById('show-appointments');

const appointmentsSection = document.getElementById('appointments');
const editProfileSection = document.getElementById('edit-info');

// Events
document.addEventListener('DOMContentLoaded', domContentLoaded);

showAppointmentsBtn.addEventListener('click', clickShowAppointments);
editProfileBtn.addEventListener('click', clickEditProfile);

async function domContentLoaded() {
  const isUserAuthenticated = localStorage.getItem('authenticated') === '1';

  // Guard condition.
  if (!isUserAuthenticated) {
    window.location.href = '../login/login.html';
    return;
  }

  const profileSection = document.getElementById('profile-info');
  const appointmentsInfoSection = document.getElementById('appointments-info');

  profileSection.textContent = 'Carregando informações...';
  appointmentsInfoSection.textContent = 'Carregando informações...';

  const clientIdentifier = localStorage.getItem('userIdentifier');

  if (!clientIdentifier) {
    console.error('User is not autenticated');
    profileSection.textContent = 'Usuário não identificado, erro ao carregar informações...';
    appointmentsInfoSection.textContent = 'Usuário não identificado, erro ao carregar informações...';
    return;
  }

  try {
    const response = await ClientsService.getById(clientIdentifier);
    profileSection.innerHTML = `
      <img src="../../assets/default-profile.jpg" alt="Foto de Perfil Default">
      <p class="name">
        ${formatName(response.firstName, response.lastName)}
      </p>
      <p class="email">${response.email}</p>
    `;
    editProfileBtn.style.display = 'inline-block';
    showAppointmentsBtn.style.display = 'inline-block';
  } catch (err) {
    console.log(err);
    profileSection.textContent = 'Erro ao carregar informações, tente novamente mais tarde...';
  }

  try {
    const response = await AppointmentsService.getClientAppointments(clientIdentifier);

    const tableBody = response.reduce((acc, appointment) => {
      const btnEnabled = appointment.status === 'RECEIVED';
      const { statusDisplay, cssClassStatus } = getAppointmentStatus(appointment.status);

      return acc + `
        <tr>
          <td>${formatDateString(appointment.date)}</td>
          <td>
            <span class="status ${cssClassStatus}">${statusDisplay}</span>
          </td>
          <td>${appointment.establishmentService.name}</td>
          <td>
            <a href="../barbearia/barbearia.html?barberId=${appointment.establishmentService.establishment.id}">
              ${appointment.establishmentService.establishment.companyName}
            </a>
          </td>
          <td title="${btnEnabled ? '' : 'Não há como cancelar'}">
            <button type="button" data-appointment-id=${appointment.id} onclick="clickCancelAppointment(this)" ${btnEnabled ? '' : 'disabled'}>
              Cancelar
            </button>
          </td>
        </tr>
      `;
    }, '');

    appointmentsInfoSection.innerHTML = `
      <table>
        <thead>
          <tr>
            <th>Data Agendada</th>
            <th>Status</th>
            <th>Serviço</th>
            <th>Barbearia</th>
            <th>Ações</th>
          </tr>
        </thead>
        <tbody>
          ${tableBody}
        </tbody>
      </table>
    `;
  } catch (err) {
    console.error(err);
    appointmentsInfoSection.textContent = 'Erro ao carregar informações, tente novamente mais tarde...';
  }
}

function clickShowAppointments(event) {
  event.preventDefault();

  if (appointmentsSection.classList.contains('hidden')) {
    appointmentsSection.classList.remove('hidden');
    editProfileSection.classList.add('hidden');
  }
}

function clickEditProfile(event) {
  event.preventDefault();

  if (editProfileSection.classList.contains('hidden')) {
    editProfileSection.classList.remove('hidden');
    appointmentsSection.classList.add('hidden');
  }
}

async function clickCancelAppointment(targetBtn) {
  const appointmentId = targetBtn.dataset.appointmentId;
  const updateStatusData = { status: 'CANCELLED' };

  try {
    await AppointmentsService.updateStatus(appointmentId, updateStatusData);
    ToastifyLib.toast(
      'Agendamento cancelado com sucesso',
      'var(--background-color-success)'
    );
    location.reload();
  } catch (error) {
    ToastifyLib.toast(
      'Erro ao cancelar agendamento, por favor tente novamente',
      'var(--background-color-error)'
    );
  }
}
