const selectClientBtn = document.getElementById('select-client-btn');
const selectEstablishmentBtn = document.getElementById('select-establishment-btn');

const clientForm = document.getElementById('client-form');
const barberForm = document.getElementById('barber-form');

const clientCepInput = document.getElementById('client-cep');
const barberCepInput = document.getElementById('barber-cep');

const logoImg = document.getElementById('img-logo');

const nextBtns = document.querySelectorAll('.next-btn');
const prevBtns = document.querySelectorAll('.prev-btn');
const stepForms = document.querySelectorAll('.step-form');


// Events
selectClientBtn.addEventListener('click', showClientForm);
selectEstablishmentBtn.addEventListener('click', showBarberForm);
clientForm.addEventListener('submit', submitClientForm);
barberForm.addEventListener('submit', submitBarberForm);
clientCepInput.addEventListener('blur', setClientAddress);
barberCepInput.addEventListener('blur', setBarberAddress);
nextBtns.forEach((button) => {
  button.addEventListener('click', (event) => {
    const formElement = event.target.closest('.step-form');
    nextStep(formElement.id);
  });
});
prevBtns.forEach(button => {
  button.addEventListener('click', (event) => {
    const formElement = event.target.closest('.step-form');
    prevStep(formElement.id);
  });
});


function showClientForm(event) {
  event.preventDefault();

  stepForms.forEach((form) => {
    form.style.display = 'none';
  });
  clientForm.style.display = 'block';
  clientForm.style.animation = 'appear-from-left 1s';
  logoImg.style.display = 'none';
  selectClientBtn.style.backgroundColor = 'var(--background-color-03)';
  selectClientBtn.style.color = 'var(--text-color-02)';
  selectEstablishmentBtn.style.backgroundColor = '#232129';
  selectEstablishmentBtn.style.color = 'var(--background-color-03)';
  barberForm.reset();

  resetSteps(clientForm.id);
}

function showBarberForm(event) {
  event.preventDefault();

  stepForms.forEach((form) => {
    form.style.display = 'none';
  });
  barberForm.style.display = 'block';
  barberForm.style.animation = 'appear-from-left 1s';
  logoImg.style.display = 'none';
  selectEstablishmentBtn.style.backgroundColor = 'var(--background-color-03)';
  selectEstablishmentBtn.style.color = 'var(--text-color-02)';
  selectClientBtn.style.backgroundColor = '#232129';
  selectClientBtn.style.color = 'var(--background-color-03)';
  clientForm.reset();

  resetSteps(barberForm.id);
}

async function submitClientForm(event) {
  event.preventDefault();

  const targetForm = event.target;
  const formData = new FormData(targetForm);

  const name = formData.get('name');
  const firstName = name.split(' ').at(0);
  const lastName = name.split(' ').at(-1) ?? '';
  const email = formData.get('email');
  const password = formData.get('password');
  const phone = formData.get('phone');
  const city = document.getElementById('client-city').value;
  const state = document.getElementById('client-state').value;

  try {
    const createData = {
      firstName,
      lastName,
      email,
      password,
      phone,
      city,
      state,
    };

    await ClientsService.create(createData);

    ToastifyLib.toast(
      'Conta criada com sucesso, redirecionando...',
      'var(--background-color-success)'
    );

    setTimeout(() => {
      location.href = '../login/login.html';
    }, 2000);
  } catch (err) {
    if (err.message === 'Conflict') {
      ToastifyLib.toast(
        'Erro ao criar conta, este e-mail já está cadastrado',
        'var(--background-color-error)',
        3000
      );
      return;
    }

    ToastifyLib.toast(
      'Erro ao criar conta, por favor tente novamente',
      'var(--background-color-error)'
    );
  }
}

async function submitBarberForm(event) {
  event.preventDefault();

  const targetForm = event.target;
  const formData = new FormData(targetForm);

  const name = formData.get('name');
  const ownerFirstName = name.split(' ').at(0);
  const ownerLastName = name.split(' ').at(-1) ?? '';
  const email = formData.get('email');
  const password = formData.get('password');
  const phone = formData.get('phone');
  const companyName = formData.get('company-name');
  const cnpj = formData.get('cnpj');
  const cep = formData.get('cep');
  const city = document.getElementById('barber-city').value;
  const state = document.getElementById('barber-state').value;
  const address = document.getElementById('barber-address').value;

  try {
    const createData = {
      ownerFirstName,
      ownerLastName,
      email,
      password,
      phone,
      companyName,
      cnpj,
      cep,
      city,
      state,
      address,
    };

    await EstablishmentService.create(createData);

    ToastifyLib.toast(
      'Conta criada com sucesso, preparando tudo e redirecionando...',
      'var(--background-color-success)',
      3000
    );

    setTimeout(() => {
      location.href = '../login/login.html';
    }, 2000);
  } catch (err) {
    if (err.message === 'Conflict') {
      ToastifyLib.toast(
        'Erro ao criar conta, barbearia já está cadastrada',
        'var(--background-color-error)',
        3000
      );
      return;
    }

    ToastifyLib.toast(
      'Erro ao criar conta, por favor tente novamente',
      'var(--background-color-error)'
    );
  }
}

async function setClientAddress(event) {
  event.preventDefault();

  const targetInput = event.target;
  const cep = targetInput.value;

  if (cep.length !== 8) {
    return;
  }

  const stateInput = document.getElementById('client-city');
  const cityInput = document.getElementById('client-state');

  try {
    const response = await getAddressByCep(cep);
    stateInput.value = response.uf;
    cityInput.value = response.localidade;
  } catch (err) {
    console.error(err);
    stateInput.value = '';
    cityInput.value = '';
  }
}

async function setBarberAddress(event) {
  event.preventDefault();

  const targetInput = event.target;
  const cep = targetInput.value;

  if (cep.length !== 8) {
    return;
  }

  const stateInput = document.getElementById('barber-city');
  const cityInput = document.getElementById('barber-state');
  const addressInput = document.getElementById('barber-address');

  try {
    const response = await getAddressByCep(cep);
    stateInput.value = response.uf;
    cityInput.value = response.localidade;
    addressInput.value = response.logradouro;
  } catch (err) {
    console.error(err);
    stateInput.value = '';
    cityInput.value = '';
    addressInput.value = '';
  }
}

function resetSteps(formId) {
  const form = document.getElementById(formId);
  form.querySelectorAll('.step').forEach((step) => {
    step.classList.remove('active');
  });
  form.querySelector('.step').classList.add('active');
}

function nextStep(formId) {
  const form = document.getElementById(formId);
  const currentStep = form.querySelector('.step.active');
  const nextStep = currentStep.nextElementSibling;
  if (nextStep && validateForm(formId)) {
    currentStep.classList.remove('active');
    nextStep.classList.add('active');
  }
}

function prevStep(formId) {
  const form = document.getElementById(formId);
  const currentStep = form.querySelector('.step.active');
  const prevStep = currentStep.previousElementSibling;
  if (prevStep) {
    currentStep.classList.remove('active');
    prevStep.classList.add('active');
  }
}

function validateForm(formId) {
  const form = document.getElementById(formId);
  let isValid = true;
  const inputs = form.querySelectorAll('.step.active input[required]');
  for (const input of inputs) {
    if (!input.checkValidity()) {
      isValid = false;
      input.reportValidity();
      break;
    }
  }
  return isValid;
}
