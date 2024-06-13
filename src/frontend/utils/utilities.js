function formatName(firstName, lastName) {
  const formattedFirstName = firstName.at(0).toUpperCase() + firstName.slice(1);
  const formattedLastName = lastName.at(0).toUpperCase() + lastName.slice(1);
  return `${formattedFirstName} ${formattedLastName}`;
}

function formatAddress(city, state) {
  const formattedCity = city.at(0).toUpperCase() + city.slice(1);
  const formattedState = state.at(0).toUpperCase() + state.slice(1);
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
