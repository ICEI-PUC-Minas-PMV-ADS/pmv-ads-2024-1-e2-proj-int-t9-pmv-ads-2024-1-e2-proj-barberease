const editProfileBtn = document.getElementById('edit-profile');
const showAppointmentsBtn = document.getElementById('show-appointments');

const appointmentsSection = document.getElementById('appointments');
const editProfileSection = document.getElementById('edit-info');

// Events
document.addEventListener('DOMContentLoaded', domContentLoaded);

showAppointmentsBtn.addEventListener('click', clickShowAppointments);
editProfileBtn.addEventListener('click', clickEditProfile);

function domContentLoaded(event) {
  // Verificar se usuário correto está logado para acessar página.
  // Caso contrário, redirecionar usuário para página de login.

  // Fazer request para buscar informações atuais do usuário
  // pelo id salvo no localStorage após login.
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
