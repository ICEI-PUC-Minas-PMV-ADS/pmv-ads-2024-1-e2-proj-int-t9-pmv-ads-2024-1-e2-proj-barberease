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

function formatAddress(city, state) {
  const formattedCity = city
    .split(' ')
    .map((word) => word.at(0).toUpperCase() + word.slice(1))
    .join(' ');
  const formattedState = state
    .split(' ')
    .map((word) => word.at(0).toUpperCase() + word.slice(1))
    .join(' ');
  return `${formattedCity}, ${formattedState}`;
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

async function getAddressByCep(cep) {
  const url = `http://viacep.com.br/ws/${cep}/json/`

  try {
    const response = await fetch(url);

    if (!response.ok) {
      throw new Error(response.statusText);
    }

    return await response.json();
  } catch (err) {
    console.error(`Request failed: ${JSON.stringify(err)}`);
    throw err;
  }
}

function logoutUser() {
  // Remove user information.
  localStorage.removeItem('authenticated');
  localStorage.removeItem('userIdentifier');
  localStorage.removeItem('userType');

  window.location.href = '../login/login.html';
}
