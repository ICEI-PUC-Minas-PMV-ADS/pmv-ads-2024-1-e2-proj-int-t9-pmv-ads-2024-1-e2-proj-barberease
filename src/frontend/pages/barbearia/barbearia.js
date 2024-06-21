const rightItemsHeader = document.getElementById('auth');

const establishmentInfoSection = document.getElementById('establishment-info');
const servicesInfoSection = document.getElementById('services-info');

const searchInput = document.getElementById('search-input');

const modal = document.getElementById('modal');
const closeModalBtn = document.getElementById('close-modal');
const modalOverlay = document.getElementById('modal-overlay');
const modalForm = document.getElementById('modal-form');
const dateInput = document.getElementById('modal-date');

const DAYS_OF_WEEK = ['SUNDAY', 'MONDAY', 'TUESDAY', 'WEDNESDAY', 'THURSDAY', 'FRIDAY', 'SATURDAY'];

// Events
document.addEventListener('DOMContentLoaded', domContentLoaded);
searchInput.addEventListener('input', filterServices);
closeModalBtn.addEventListener('click', closeModal);
modalForm.addEventListener('submit', submitScheduleForm);

async function domContentLoaded() {
  const isClientAuthenticated =
    localStorage.getItem('authenticated') === '1' &&
    localStorage.getItem('userType') === 'Client';

  const isEstablishmentAuthenticated =
    localStorage.getItem('authenticated') === '1' &&
    localStorage.getItem('userType') === 'Establishment';

  const isUserAuthenticated = isClientAuthenticated || isEstablishmentAuthenticated;

  // Guard condition.
  if (!isUserAuthenticated) {
    location.href = '../pagina-inicial/homepage.html';
    return;
  }

  const queryString = new URLSearchParams(location.search);
  const params = new URLSearchParams(queryString);
  const establishmentId = params.get('id');

  // Guard condition, this page needs establishmentId defined.
  if (!establishmentId) {
    location.href = '../pagina-inicial/homepage.html';
    return;
  }

  if (isClientAuthenticated) {
    rightItemsHeader.innerHTML = `
      <a href="../cliente-dashboard/cliente-dashboard.html" title="Ir para o perfil">
        <i class="bi bi-person-circle"></i>
        Perfil
      </a>
      <button onclick="logoutUser()" class="buttonHome" title="Clique para sair">
        <i class="bi bi-box-arrow-left"></i>
        SAIR
      </button>
    `;
  } else if (isEstablishmentAuthenticated) {
    rightItemsHeader.innerHTML = `
      <a href="../barbearia-dashboard/barbearia-dashboard.html" title="Ir para o dashboard">
        <i class="bi bi-person-circle"></i>
        Dashboard
      </a>
      <button onclick="logoutUser()" class="buttonHome" title="Clique para sair">
        <i class="bi bi-box-arrow-left"></i>
        SAIR
      </button>
    `;
  }

  establishmentInfoSection.textContent = 'Carregando informações...';
  servicesInfoSection.textContent = 'Carregando informações...';
  dateInput.value = getTodayDate();
  dateInput.min = getTodayDate();

  try {
    const response = await EstablishmentService.getByIdDetails(establishmentId);

    const { status, cssClassStatus, openingTime, closingTime } = getEstablishmentStatus(response.establishmentPeriods);
    const formattedPhone = formatPhoneNumber(response.phone) ?? 'Não cadastrado';
    const formattedTimes = openingTime && closingTime ? `${openingTime} — ${closingTime}` : 'Fechado';

    establishmentInfoSection.innerHTML = `
      <img src="../../assets/logo.jpeg" alt="Foto da Barbearia Default">
      <h3 class="company-name" title="${formatCompanyName(response.companyName)}">
        ${formatCompanyName(response.companyName)}
      </h3>
      <p title="${formatAddress(response.city, response.state, response.address)}">
        <i class="bi bi-geo-alt-fill"></i>
        ${formatAddress(response.city, response.state, response.address)}
      </p>
      <p title="${formattedPhone}">
        <i class="bi bi-telephone-fill"></i>
        ${formattedPhone}
      </p>
      <p title="${formattedTimes}">
        <i class="bi bi-clock-fill"></i>
        ${formattedTimes}
      </p>
      <p title="${status}">
        <i class="bi bi-tag-fill"></i>
        <span class="status ${cssClassStatus}">${status}</span>
      </p>
    `;

    const disabled = status === 'Fechado' || isEstablishmentAuthenticated;
    let todayAvailableTimes = JSON.stringify([]);

    if (!disabled) {
      const today = new Date();
      const dayOfWeek = DAYS_OF_WEEK[today.getDay()];
      const period = response.establishmentPeriods.find((p) => p.dayOfWeek === dayOfWeek);
      todayAvailableTimes = getAvailableTimes(period.openingTime, period.closingTime, period.timeBetweenService);
    }

    const servicesCards = response.establishmentServices.reduce((acc, service) => {
      const dataService = JSON.stringify({
        id: service.id,
        price: service.price,
        name: service.name,
        todayAvailableTimes: todayAvailableTimes,
      });

      return acc + `
        <div class="card">
          <img src="../../assets/logo.jpeg" alt="Imagem default com a logo da BarberEase">
          <div class="card-body">
            <h3 class="card-title" title="${formatServiceName(service.name)}">
              ${formatServiceName(service.name)}
            </h3>
            <p class="card-description" class="service-description" title="${service.description || 'Não fornecido'}">
              ${formatServiceDescription(service.description)}
            </p>
            <p id="category" title="${service.category}">
              <i class="bi bi-tag"></i>
              ${service.category}
            </p>
            <p id="price" title="${formatServicePrice(service.price)}">
              <i class="bi bi-currency-dollar"></i>
              ${formatServicePrice(service.price)}
            </p>
            <button
              class="open-modal-btn"
              title="${disabled ? 'Você não pode agendar agora' : 'Clique para ver horários'}"
              data-service='${dataService}'
              onclick="openModal(this)"
              ${disabled ? 'disabled' : ''}
            >
              Ver horários
              <i class="bi bi-eye"></i>
            </button>
          </div>
        </div>
      `;
    }, '');

    if (!servicesCards) {
      servicesInfoSection.textContent = 'Esta barbearia não possui nenhum serviço cadastrado ainda...'
    } else {
      servicesInfoSection.innerHTML = servicesCards;
    }
  } catch (err) {
    console.error(err);
    establishmentInfoSection.textContent = 'Erro ao carregar informações, tente novamente mais tarde...';
    servicesInfoSection.textContent = 'Erro ao carregar informações, tente novamente mais tarde...';
  }
}

function filterServices() {
  const searchTerm = searchInput.value.trim().toLowerCase();
  const cards = document.querySelectorAll('.card');

  cards.forEach((card) => {
    const serviceName = card.querySelector('.card-title').textContent.trim().toLowerCase();
    const serviceCategory = card.querySelector('#category').textContent.trim().toLowerCase();
    const servicePrice = card.querySelector('#price').textContent.replace('R$', '').trim();

    if (serviceName.includes(searchTerm) || serviceCategory.includes(searchTerm) || servicePrice.includes(searchTerm)) {
      card.style.display = 'flex';
    } else {
      card.style.display = 'none';
    }
  });
}

function openModal(targetBtn) {
  const dataService = JSON.parse(targetBtn.dataset.service);

  const availableTimesOptions = dataService.todayAvailableTimes.reduce((acc, time, index) => {
    return acc + `<option value="${time}" ${index === 0 ? 'selected' : ''}>${time}</option>`;
  }, '');

  modalForm.dataset.serviceId = dataService.id;
  document.getElementById('modal-header').textContent = dataService.name;
  document.getElementById('modal-price').textContent = formatServicePrice(dataService.price);
  document.getElementById('modal-time').innerHTML = availableTimesOptions;

  modalOverlay.classList.add('show');
}

function closeModal(event) {
  event.preventDefault();

  modalOverlay.classList.remove('show');
  modalForm.reset();
}

async function submitScheduleForm(event) {
  event.preventDefault();

  const targetForm = event.target;
  const formData = new FormData(targetForm);

  const date = formData.get('date');
  const time = formData.get('time');;
  const appointmentDate = `${date}T${time}:00Z`;

  try {
    const clientId = localStorage.getItem('userIdentifier');
    const establishmentServiceId = targetForm.dataset.serviceId;
    const createData = { date: appointmentDate, status: 'RECEIVED', clientId, establishmentServiceId };

    await AppointmentsService.create(createData);

    ToastifyLib.toast(
      `Agendamento criado com sucesso, acompanhe pelo seu dashboard`,
      'var(--background-color-success)',
      3000
    );

    targetForm.reset();
  } catch (err) {
    console.error(err);
    if (err.message === 'Conflict') {
      ToastifyLib.toast(
        `Erro ao criar agendamento, já existe um agendamento para esse horário, por favor tente outro horário`,
        'var(--background-color-error)',
        3000
      );
      return;
    }
    ToastifyLib.toast(
      'Erro ao criar agendamento, por favor tente novamente',
      'var(--background-color-error)'
    );
  }
}
