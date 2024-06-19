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

function submitClientForm(event) {
  event.preventDefault();
  console.log('submitClientForm');
}

function submitBarberForm(event) {
  event.preventDefault();
  console.log('submitBarberForm');
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
  if (nextStep) {
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
