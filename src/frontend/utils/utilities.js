function formatName(firstName, lastName) {
  const formattedFirstName = firstName.at(0).toUpperCase() + firstName.slice(1);
  const formattedLastName = lastName.at(0).toUpperCase() + lastName.slice(1);
  return `${formattedFirstName} ${formattedLastName}`;
}

function formatCompanyName(companyName) {
  return companyName
    .split(' ')
    .map((word) => word.at(0).toUpperCase() + word.slice(1))
    .join(' ');
}

function formatServiceName(serviceName) {
  return serviceName
    .split(' ')
    .map((word) => word.at(0).toUpperCase() + word.slice(1))
    .join(' ');
}

function formatServiceDescription(serviceDescription) {
  if (!serviceDescription) {
    return 'Não fornecido';
  }

  if (serviceDescription.length > 50) {
    return serviceDescription.slice(0, 50) + '...'
  }

  return serviceDescription
}

function formatServicePrice(servicePrice) {
  return new Intl.NumberFormat('pt-BR', {
    style: 'currency',
    currency: 'BRL'
  }).format(servicePrice);
}

function formatAddress(city, state, address) {
  const formattedCity = city
    .split(' ')
    .map((word) => word.at(0).toUpperCase() + word.slice(1))
    .join(' ');
  const formattedState = state
    .split(' ')
    .map((word) => word.at(0).toUpperCase() + word.slice(1))
    .join(' ');

  let formattedAddress;
  if (address) {
    formattedAddress = address
      .split(' ')
      .map((word) => word.at(0).toUpperCase() + word.slice(1))
      .join(' ');
  }

  return `${formattedAddress ? formattedAddress + ', ' : ''}${formattedCity}, ${formattedState}`;
}

function formatDateString(dateString) {
  const date = new Date(dateString);
  return date.toLocaleString('pt-br', {
    day: '2-digit',
    month: '2-digit',
    year: 'numeric',
    hour: '2-digit',
    minute: '2-digit',
  });
}

function formatPhoneNumber(phoneNumber) {
  const cleaned = ('' + phoneNumber).replace(/\D/g, '');

  const match = cleaned.match(/^(\d{2})(\d{5})(\d{4})$/);

  if (match) {
    return `(${match[1]}) ${match[2]}-${match[3]}`;
  }

  return null;
}

function encodeUrl(url) {
  const encoded = encodeURIComponent(url);
  return encoded.toString();
}

function getAppointmentStatus(status) {
  const displayStatustMap = {
    RECEIVED: 'Pendente',
    CONFIRMED: 'Confirmado',
    CANCELLED: 'Cancelado',
  }
  const cssClassStatusMap = {
    RECEIVED: 'received',
    CONFIRMED: 'confirmed',
    CANCELLED: 'cancelled',
  }

  return {
    statusDisplay: displayStatustMap[status],
    cssClassStatus: cssClassStatusMap[status],
  }
}

function getDayOfWeeek(day) {
  const periodWeekDayMap = {
    MONDAY: 'Segunda-feira',
    TUESDAY: 'Terça-feira',
    WEDNESDAY: 'Quarta-feira',
    THURSDAY: 'Quinta-feira',
    FRIDAY: 'Sexta-feira',
    SATURDAY: 'Sábado',
    SUNDAY: 'Domingo',
  };

  return periodWeekDayMap[day];
}

function getEstablishmentStatus(periods) {
  const daysOfWeek = ['SUNDAY', 'MONDAY', 'TUESDAY', 'WEDNESDAY', 'THURSDAY', 'FRIDAY', 'SATURDAY'];
  const cssClassStatusMap = {
    Aberto: 'open',
    Fechado: 'closed',
  }

  const today = new Date();
  const dayOfWeek = daysOfWeek[today.getDay()];
  let status;

  const todayPeriod = periods.find((p) => p.dayOfWeek === dayOfWeek);

  if (todayPeriod.isClosed) {
    status = 'Fechado';
  }

  const openingTime = parseTimeString(todayPeriod.openingTime);
  const closingTime = parseTimeString(todayPeriod.closingTime);

  status = today >= openingTime && today <= closingTime ? 'Aberto' : 'Fechado';

  return {
    status,
    openingTime: todayPeriod.openingTime,
    closingTime: todayPeriod.closingTime,
    cssClassStatus: cssClassStatusMap[status],
  }
}

function parseTimeString(timeString) {
  const [hours, minutes] = timeString.split(':');
  const now = new Date();
  now.setHours(parseInt(hours), parseInt(minutes), 0, 0);
  return now;
}

async function getAddressByCep(cep) {
  const url = `http://viacep.com.br/ws/${cep}/json/`

  try {
    const response = await fetch(url);

    if (!response.ok || response.erro) {
      throw new Error(response.statusText);
    }

    const json = await response.json();

    if (json.erro) {
      throw new Error('Not Found');
    }

    return json;
  } catch (err) {
    console.error(`Request failed: ${err.message}`);
    throw err;
  }
}

function logoutUser() {
  // Remove user information.
  localStorage.removeItem('authenticated');
  localStorage.removeItem('userIdentifier');
  localStorage.removeItem('userType');

  location.href = '../login/login.html';
}

function getTodayDate() {
  const today = new Date();
  return today.toISOString().split('T')[0];
}

function getAvailableTimes(openingTime, closingTime, timeBetweenServices) {
  function timeStringToMinutes(time) {
    const [hours, minutes] = time.split(':').map(Number);
    return hours * 60 + minutes;
  }

  function minutesToTimeString(minutes) {
    const hours = Math.floor(minutes / 60).toString().padStart(2, '0');
    const mins = (minutes % 60).toString().padStart(2, '0');
    return `${hours}:${mins}`;
  }

  const openingMinutes = timeStringToMinutes(openingTime);
  const closingMinutes = timeStringToMinutes(closingTime);
  const serviceInterval = timeStringToMinutes(timeBetweenServices);
  const availableTimes = [];

  for (let currentTime = openingMinutes; currentTime + serviceInterval <= closingMinutes; currentTime += serviceInterval) {
    availableTimes.push(minutesToTimeString(currentTime));
  }

  return availableTimes;
}
