const rightItemsHeader = document.getElementById('auth');
const searchForm = document.getElementById('search-form');

// Events
document.addEventListener('DOMContentLoaded', domContentLoaded);
document.addEventListener('submit', submitSearchForm);

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

function submitSearchForm(event) {
  event.preventDefault();

  // Pegar id do usuário logado, buscar o usuário pelo id
  // Guardar a cidade e o estado do mesmo e usar como search
  // term para a página de barbearias para filtrar por esses
  // filtros.
  // Caso o usuário não esteja logado ou a api dê erro ao buscar
  // simplesmente buscar todas as barbearias com o term procurado.

  const targetForm = event.target;
  const formData = new FormData(targetForm);

  const searchTerm = formData.get('search-term');

  location.href = `../barbearias/barbearias.html?search=${searchTerm}`
}
