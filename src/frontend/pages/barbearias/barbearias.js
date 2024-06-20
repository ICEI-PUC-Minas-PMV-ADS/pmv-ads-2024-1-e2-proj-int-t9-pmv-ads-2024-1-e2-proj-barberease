const rightItemsHeader = document.getElementById('auth');

const cards = document.getElementById('cards');
const searchInput = document.getElementById('search-input');


// Events
document.addEventListener('DOMContentLoaded', domContentLoaded);
searchInput.addEventListener('input', filterEstablishments);

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

  cards.textContent = 'Carregando barbearias...'

  try {
    const response = await EstablishmentService.getAllDetails();

    const establishmentCards = response.reduce((acc, establishment) => {
      const { status, cssClassStatus, openingTime, closingTime } = getEstablishmentStatus(establishment.establishmentPeriods);
      const formattedPhone = formatPhoneNumber(establishment.phone) ?? 'Não cadastrado';
      const formattedTimes = openingTime && closingTime ? `${openingTime} — ${closingTime}` : 'Fechado';

      return acc + `
        <div class="card">
          <img class="card-img" src="../../assets/logo.jpeg" alt="Imagem defaukt da Barbearia">
          <h2 class="card-title" title="${formatCompanyName(establishment.companyName)}">
            <a href="../barbearia/barbearia.html?id=${encodeUrl(establishment.id)}">
              ${formatCompanyName(establishment.companyName)}
            </a>
          </h2>
          <p id="address" title="${formatAddress(establishment.city, establishment.state, establishment.address)}">
            <i class="bi bi-geo-alt-fill"></i>
            ${formatAddress(establishment.city, establishment.state, establishment.address)}
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
          <a href="../barbearia/barbearia.html?id=${encodeUrl(establishment.id)}" class="go-page-btn">
            Visitar Página
            <i class="bi bi-box-arrow-up-right"></i>
          </a>
        </div>
      `;
    }, '');

    if (!establishmentCards) {
      cards.textContent = 'Ainda não temos barbearias parceiras cadastradas em nosso site, volte em outro momento...'
    } else {
      cards.innerHTML = establishmentCards;

      const queryString = new URLSearchParams(location.search);
      const params = new URLSearchParams(queryString);
      const searchTerm = params.get('search');
      console.log(searchTerm);
      if (searchTerm) {
        searchInput.value = searchTerm;
        filterEstablishments();
      }
    }
  } catch (err) {
    console.error(err);
    cards.textContent = 'Erro ao carregar barbearias, tente novamente mais tarde...';
  }
}

function filterEstablishments() {
  const searchTerm = searchInput.value.toLowerCase();
  const cards = document.querySelectorAll('.card');

  cards.forEach((card) => {
    const barberName = card.querySelector('.card-title a').textContent.toLowerCase();
    const barberAddress = card.querySelector('#address').textContent.toLowerCase();

    if (barberName.includes(searchTerm) || barberAddress.includes(searchTerm)) {
      card.style.display = 'block';
    } else {
      card.style.display = 'none';
    }
  });
}
