const loginForm = document.getElementById('login-form');

// Events
loginForm.addEventListener('submit', submitLoginForm);

async function submitLoginForm(event) {
  event.preventDefault();

  const targetForm = event.target;
  const formData = new FormData(targetForm);

  const email = formData.get('email');
  const password = formData.get('password');
  const isEstablishment = formData.get('is-establishment');
  const userType = isEstablishment ? 'Establishment' : 'Client';

  const loginData = { email, password, userType };

  try {
    const response = await AuthService.login(loginData);

    if (response.authenticated) {
      ToastifyLib.toast(
        'Autenticado com sucesso, redirecionando...',
        'var(--background-color-success)'
      );

      // Sets some information on localStorage.
      localStorage.setItem('authenticated', '1');
      localStorage.setItem('userIdentifier', response.identifier);
      localStorage.setItem('userType', response.userType);

      if (response.userType === 'Client') {
        setTimeout(() => {
          window.location.href = '../cliente-dashboard/cliente-dashboard.html';
        }, 2000);
        return;
      }

      setTimeout(() => {
        window.location.href = '../pagina-inicial/pagina-inicial.html'; // Change this later to establishment dashboard
      }, 2000);
      return;
    }

    ToastifyLib.toast(
      'Erro ao se autenticar, por favor verifique suas credenciais',
      'var(--background-color-error)'
    );
  } catch (err) {
    ToastifyLib.toast(
      'Erro ao se autenticar, por favor tente novamente',
      'var(--background-color-error)'
    );
  }
}
