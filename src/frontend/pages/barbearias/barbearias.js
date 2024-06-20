const rightItemsHeader = document.getElementById('auth');

// Events
document.addEventListener('DOMContentLoaded', domContentLoaded)


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
}

async function barber() {
  try {
    const response = await EstablishmentService.getAll();
    const hghghg = document.getElementById("card").innerHTML;
    let lista = document.getElementById("myList");
    for (let i = 0; i < response.length; ++i) {
      const li = document.createElement('li');
      li.innerHTML = hghghg
      document.getElementById("dfg").setAttribute("id", i)
      document.getElementById("123").setAttribute("id", "c" + i)
      document.getElementById("345").setAttribute("id", "d" + i)
      document.getElementById("901").setAttribute("id", "e" + i)
      document.getElementById("c" + i).innerText = response[i].companyName;
      document.getElementById("d" + i).innerText = response[i].phone;
      document.getElementById("e" + i).innerText = response[i].address + ". " + response[i].city + " - " + response[i].state
      lista.appendChild(li);
    }
    lista.removeChild(lista.lastChild)
    return;
  }
  catch (err) {
    console.error(`failed: ${JSON.stringify(err)}`);
    throw err;
  }
}

async function barberpage(ide) {
  const response = await GetAllBarberService.getall();
  for (let i = 0; i < response.length; ++i) {
    if (i == ide) {
      const q = response[i].id
      window.location.href = '../barbearia/barbearia.html'
      localStorage.setItem('barber', 'https://barberease.azurewebsites.net/api/Establishments/' + q + '/details')
      return;
    }
  }
}
