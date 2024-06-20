const rightItemsHeader = document.getElementById('auth');

// Events
document.addEventListener('DOMContentLoaded', domContentLoaded);

async function domContentLoaded() {
  const isClientAuthenticated =
    localStorage.getItem('authenticated') === '1' &&
    localStorage.getItem('userType') === 'Client';

  const isEstablishmentAuthenticated =
    localStorage.getItem('authenticated') === '1' &&
    localStorage.getItem('userType') === 'Establishment';

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
    return;
  }

  if (isEstablishmentAuthenticated) {
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
    return;
  }
}
