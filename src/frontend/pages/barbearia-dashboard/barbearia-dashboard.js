const editProfileBtn = document.getElementById('edit-profile');
const showAppointmentsBtn = document.getElementById('show-appointments');
const showServicesBtn = document.getElementById('show-services');
const showPeriodsBtn = document.getElementById('show-periods');

const appointmentsSection = document.getElementById('appointments');
const editProfileSection = document.getElementById('edit-info');
const servicesSection = document.getElementById('services');

const editForm = document.getElementById('edit-form');
const cepInput = document.getElementById('cep');
const addServiceBtn = document.getElementById('add-service-btn');
const addServiceForm = document.getElementById('add-service-form');


// Events
document.addEventListener('DOMContentLoaded', domContentLoaded);

showAppointmentsBtn.addEventListener('click', clickShowAppointments);
editProfileBtn.addEventListener('click', clickEditProfile);
showServicesBtn.addEventListener('click', clickShowServices);
showPeriodsBtn.addEventListener('click', clickShowPeriods);

editForm.addEventListener('submit', submitEditForm);
cepInput.addEventListener('blur', setAddressInfo);
addServiceBtn.addEventListener('click', clickAddService);
addServiceForm.addEventListener('submit', submitAddServiceForm);


async function domContentLoaded() {
  const isUserAuthenticated =
    localStorage.getItem('authenticated') === '1' &&
    localStorage.getItem('userType') === 'Establishment';

  // Guard condition.
  if (!isUserAuthenticated) {
    window.location.href = '../login/login.html';
    return;
  }

  const profileSection = document.getElementById('profile-info');
  const appointmentsInfoSection = document.getElementById('appointments-info');
  const servicesInfoSection = document.getElementById('services-info');

  profileSection.textContent = 'Carregando informações...';
  appointmentsInfoSection.textContent = 'Carregando informações...';
  servicesInfoSection.textContent = 'Carregando informações...'

  const establishmentIdentifier = localStorage.getItem('userIdentifier');

  if (!establishmentIdentifier) {
    console.error('User is not autenticated');
    profileSection.textContent = 'Usuário não identificado, erro ao carregar informações...';
    appointmentsInfoSection.textContent = 'Usuário não identificado, erro ao carregar informações...';
    servicesInfoSection.textContent = 'Usuário não identificado, erro ao carregar informações...';
    return;
  }

  try {
    const response = await EstablishmentService.getById(establishmentIdentifier);

    profileSection.innerHTML = `
      <img src="../../assets/logo.jpeg" alt="Foto de Perfil Default">
      <p class="name" title="${formatCompanyName(response.companyName)}">
        ${formatCompanyName(response.companyName)}
      </p>
      <p class="email" title="${response.email}">
        <i class="bi bi-envelope-fill"></i>
        ${response.email}
      </p>
      <p title="${formatAddress(response.city, response.state)}">
        <i class="bi bi-geo-alt-fill"></i>
        ${formatAddress(response.city, response.state)}
      </p>
    `;

    if (response.phone) {
      const formattedPhone = formatPhoneNumber(response.phone);
      if (formattedPhone) {
        profileSection.innerHTML += `
          <p title="${formattedPhone}">
            <i class="bi bi-telephone-fill"></i>
            ${formattedPhone}
          </p>
        `;
      }
    }

    editProfileBtn.style.display = 'inline-block';
    showAppointmentsBtn.style.display = 'inline-block';
    showServicesBtn.style.display = 'inline-block';
    showPeriodsBtn.style.display = 'inline-block';
  } catch (err) {
    console.error(err);
    profileSection.textContent = 'Erro ao carregar informações, tente novamente mais tarde...';
  }

  try {
    const response = await AppointmentsService.getEstablishmentAppointments(establishmentIdentifier);

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
          <td>${formatName(appointment.client.firstName, appointment.client.lastName)}</td>
          <td class="actions" title="${btnEnabled ? '' : 'Não há como confirmar/cancelar'}">
            <button
              type="button"
              data-appointment-id=${appointment.id}
              ${btnEnabled ? 'onclick="clickConfirmAppointment(this)"' : ''}
              ${btnEnabled ? '' : 'disabled'}
            >
              Confirmar
            </button>
            <button
              type="button"
              data-appointment-id=${appointment.id}
              ${btnEnabled ? 'onclick="clickCancelAppointment(this)"' : ''}
              ${btnEnabled ? '' : 'disabled'}
            >
              Cancelar
            </button>
          </td>
        </tr>
      `;
    }, '');

    if (!tableBody) {
      appointmentsInfoSection.textContent = 'Não há nenhum agendamento por aqui...'
    } else {
      appointmentsInfoSection.innerHTML = `
        <table>
          <thead>
            <tr>
              <th>Data Agendada</th>
              <th>Status</th>
              <th>Serviço</th>
              <th>Cliente</th>
              <th>Ações</th>
            </tr>
          </thead>
          <tbody>
            ${tableBody}
          </tbody>
        </table>
      `;
    }
  } catch (err) {
    console.error(err);
    appointmentsInfoSection.textContent = 'Erro ao carregar informações, tente novamente mais tarde...';
  }

  try {
    const response = await EstablishmentServiceService.getEstablishmentServices(establishmentIdentifier);

    const servicesCards = response.reduce((acc, service) => {
      return acc + `
        <div class="service-card">
          <img src="../../assets/logo.jpeg" alt="Imagem default com a logo da BaberEase">
          <div class="service-info">
            <input type="text" value="${service.name}" placeholder="Nome" disabled>
            <input type="text" value="${service.category}" placeholder="Categoria" disabled>
            <input type="text" value="${service.description || ''}" placeholder="Descrição" disabled>
            <input type="number" value="${service.price}" disabled>
            <div class="service-buttons">
              <button
                class="edit"
                title="Clique para editar"
                data-service-id="test"
                onclick="clickEditService(this)"
              >
                <i class="bi bi-pencil-square"></i>
              </button>
              <button
                class="delete"
                title="Clique para deletar"
                data-service-id="${service.id}"
                onclick="clickDeleteService(this)"
              >
                <i class="bi bi-trash-fill"></i>
              </button>
            </div>
          </div>
        </div>
      `;
    }, '');

    if (!servicesCards) {
      servicesInfoSection.textContent = 'Não há nenhum serviço por aqui, você precisa adicionar serviços para que os clientes possam fazer agendamentos...'
    } else {
      servicesInfoSection.innerHTML = servicesCards;
    }
  } catch (err) {
    console.error(err);
    servicesInfoSection.textContent = 'Erro ao carregar informações, tente novamente mais tarde...';
  }
}

function clickShowAppointments(event) {
  event.preventDefault();

  if (appointmentsSection.classList.contains('hidden')) {
    appointmentsSection.classList.remove('hidden');
    editProfileSection.classList.add('hidden');
    servicesSection.classList.add('hidden');
  }
}

function clickEditProfile(event) {
  event.preventDefault();

  if (editProfileSection.classList.contains('hidden')) {
    editProfileSection.classList.remove('hidden');
    appointmentsSection.classList.add('hidden');
    servicesSection.classList.add('hidden');
  }
}

function clickShowServices(event) {
  event.preventDefault();

  if (servicesSection.classList.contains('hidden')) {
    servicesSection.classList.remove('hidden');
    appointmentsSection.classList.add('hidden');
    editProfileSection.classList.add('hidden');
  }
}

function clickShowPeriods(event) {
  event.preventDefault();
  console.log('Show periods');
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

    setTimeout(() => {
      location.reload();
    }, 2000);
  } catch (error) {
    ToastifyLib.toast(
      'Erro ao cancelar agendamento, por favor tente novamente',
      'var(--background-color-error)'
    );
  }
}

async function clickConfirmAppointment(targetBtn) {
  const appointmentId = targetBtn.dataset.appointmentId;
  const updateStatusData = { status: 'CONFIRMED' };

  try {
    await AppointmentsService.updateStatus(appointmentId, updateStatusData);

    ToastifyLib.toast(
      'Agendamento confirmado com sucesso',
      'var(--background-color-success)'
    );

    setTimeout(() => {
      location.reload();
    }, 2000);
  } catch (error) {
    ToastifyLib.toast(
      'Erro ao confirmar o agendamento, por favor tente novamente',
      'var(--background-color-error)'
    );
  }
}

async function submitEditForm(event) {
  event.preventDefault();

  const targetForm = event.target;
  const formData = new FormData(targetForm);

  const updateData = {};

  const name = formData.get('name');
  if (name) {
    updateData.ownerFirstName = name.split(' ').at(0);
    updateData.ownerLastName = name.split(' ').at(-1) ?? '';
  }

  const email = formData.get('email');
  if (email) {
    updateData.email = email;
  }

  const password = formData.get('password');
  if (password) {
    updateData.password = password;
  }

  const companyName = formData.get('company-name');
  if (companyName) {
    updateData.companyName = companyName;
  }

  const cnpj = formData.get('cnpj');
  if (cnpj) {
    updateData.cnpj = cnpj;
  }

  const cep = formData.get('cep');
  if (cep) {
    updateData.cep = cep;
    updateData.city = document.getElementById('city').value;
    updateData.state = document.getElementById('state').value;
    updateData.address = document.getElementById('address').value;
  }

  const phone = formData.get('phone');
  if (phone) {
    updateData.phone = phone;
  }

  try {
    const establishmentIdentifier = localStorage.getItem('userIdentifier');
    await EstablishmentService.updateById(establishmentIdentifier, updateData);

    ToastifyLib.toast(
      'Informações gerais atualizadas com sucesso',
      'var(--background-color-success)'
    );

    setTimeout(() => {
      location.reload();
    }, 2000);
  } catch (err) {
    ToastifyLib.toast(
      'Erro ao atualizar informações, por favor tente novamente',
      'var(--background-color-error)'
    );
  }
}

async function setAddressInfo(event) {
  event.preventDefault();

  const targetInput = event.target;
  const cep = targetInput.value;

  if (cep.length !== 8) {
    return;
  }

  const stateInput = document.getElementById('state');
  const cityInput = document.getElementById('city');
  const addressInput = document.getElementById('address');

  try {
    const response = await getAddressByCep(cep);
    stateInput.value = response.uf;
    cityInput.value = response.localidade;
    addressInput.value = response.logradouro;
  } catch (err) {
    console.error(err);
    stateInput.value = '';
    cityInput.value = '';
    addressInput.value = '';
  }
}

function clickAddService(event) {
  event.preventDefault();

  if (addServiceForm.classList.contains('show')) {
    addServiceForm.classList.remove('show');
  } else {
    addServiceForm.classList.add('show');
  }
}

async function submitAddServiceForm(event) {
  event.preventDefault();

  const targetForm = event.target;
  const formData = new FormData(targetForm);
  console.log('helooooo');
  // const updateData = {};

  // const name = formData.get('name');
  // if (name) {
  //   updateData.ownerFirstName = name.split(' ').at(0);
  //   updateData.ownerLastName = name.split(' ').at(-1) ?? '';
  // }

  // const email = formData.get('email');
  // if (email) {
  //   updateData.email = email;
  // }

  // const password = formData.get('password');
  // if (password) {
  //   updateData.password = password;
  // }

  // const companyName = formData.get('company-name');
  // if (companyName) {
  //   updateData.companyName = companyName;
  // }

  // const cnpj = formData.get('cnpj');
  // if (cnpj) {
  //   updateData.cnpj = cnpj;
  // }

  // const cep = formData.get('cep');
  // if (cep) {
  //   updateData.cep = cep;
  //   updateData.city = document.getElementById('city').value;
  //   updateData.state = document.getElementById('state').value;
  //   updateData.address = document.getElementById('address').value;
  // }

  // const phone = formData.get('phone');
  // if (phone) {
  //   updateData.phone = phone;
  // }

  // try {
  //   const establishmentIdentifier = localStorage.getItem('userIdentifier');
  //   await EstablishmentService.updateById(establishmentIdentifier, updateData);

  //   ToastifyLib.toast(
  //     'Informações gerais atualizadas com sucesso!',
  //     'var(--background-color-success)'
  //   );

  //   setTimeout(() => {
  //     location.reload();
  //   }, 2000);
  // } catch (err) {
  //   ToastifyLib.toast(
  //     'Erro ao atualizar informações, por favor tente novamente',
  //     'var(--background-color-error)'
  //   );
  // }
}

async function clickEditService(targetBtn) {
  const serviceInfoWrapper = targetBtn.parentElement.parentElement;
  const [nameInput, categoryInput, descriptionInput, priceInput] = serviceInfoWrapper.querySelectorAll('input');

  const isEditing = nameInput.disabled;
  nameInput.disabled = !isEditing;
  categoryInput.disabled = !isEditing;
  descriptionInput.disabled = !isEditing;
  priceInput.disabled = !isEditing;

  targetBtn.innerHTML = isEditing ? '<i class="bi bi-floppy"></i>' : '<i class="bi bi-pencil-square"></i>';
  targetBtn.title = isEditing ? 'Clique para salvar' : 'Clique para editar';

  if (!isEditing) {
    const name = nameInput.value;
    const category = categoryInput.value;
    const description = descriptionInput.value;
    const price = priceInput.value;

    const updateData = { name, category, description, price };

    console.log(updateData);
  }
}

async function clickDeleteService(targetBtn) {
  const confirmed = confirm('Você gostaria de deletar esse serviço? Isso deletará todos os agendamentos vinculados a esse serviço.');

  if (!confirmed) {
    return;
  }

  const serviceCard = targetBtn.parentElement.parentElement.parentElement;
  const servicesInfoSection = serviceCard.parentElement;
  const serviceId = targetBtn.dataset.serviceId;

  try {
    await EstablishmentServiceService.deleteById(serviceId);

    ToastifyLib.toast(
      `Serviço deletado com sucesso`,
      'var(--background-color-success)'
    );

    if (servicesInfoSection.children.length === 1) {
      servicesInfoSection.textContent = 'Não há nenhum serviço por aqui, você precisa adicionar serviços para que os clientes possam fazer agendamentos...';
      return;
    }

    serviceCard.outerHTML = '';
  } catch (err) {
    ToastifyLib.toast(
      'Erro ao deletar serviço, por favor tente novamente',
      'var(--background-color-error)'
    );
  }
}
