function formatName(firstName, lastName) {
  const formattedFirstName = firstName.at(0).toUpperCase() + firstName.slice(1);
  const formattedLastName = lastName.at(0).toUpperCase() + lastName.slice(1);
  return `${formattedFirstName} ${formattedLastName}`;
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
