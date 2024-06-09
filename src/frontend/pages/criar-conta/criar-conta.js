const clientForm = document.getElementById('client-form');
const barberForm = document.getElementById('barber-form');
const dataForm = document.getElementById('data-form');

clientForm.addEventListener('submit', submitClientForm);
barberForm.addEventListener('submit', submitBarberForm);
dataForm.addEventListener('submit', submitDataForm);

async function submitDataForm(event){
    event.preventDefault();

    const targetForm = event.target;
    const formData = new FormData(targetForm);

    const cep = formData.get('cep');

    const url = `http://viacep.com.br/ws/${cep}/json/`
    const dados = await fetch(url);
    const endereco = await dados.json();

    const name = formData.get('name');
    const email = formData.get('email');
    const password = formData.get('password');
    const number = formData.get('number');
    const city = endereco.localidade;
    const uf = endereco.uf;

    console.log(endereco);
}

async function submitClientForm(event) {
    event.preventDefault();

    const targetForm = event.target;
    const formData = new FormData(targetForm);

    const phone = formData.get('telephone');
}

async function submitBarberForm(event) {
    event.preventDefault();

    const targetForm = event.target;
    const formData = new FormData(targetForm);

    const razao = formData.get('razao');
    const cnpj = formData.get('cnpj');
}

//Functions
var currentStep = 1;
var totalSteps = 2;

function nextStep() {
    if(dataForm.reportValidity()){
        if (currentStep < totalSteps) {
            var currentSection = document.getElementById("step" + currentStep);
            currentSection.style.display = "none";
    
            currentStep++;
    
            var nextSection = document.getElementById("step" + currentStep);
            nextSection.style.display = "flex";
        }
    }
}

function previousStep() {
    if (currentStep > 1) {
        var currentSection = document.getElementById("step" + currentStep);
        currentSection.style.display = "none";

        currentStep--;

        var previousSection = document.getElementById("step" + currentStep);
        previousSection.style.display = "flex";
    }
}

function toggleForm(form, button){

    document.getElementById("client-form").style.display = "none";
    document.getElementById("barber-form").style.display = "none";
    document.getElementById(form).style.display = "block";
    document.getElementById(button).style.background = "var(--background-color-03)";
    document.getElementById(button).style.color = "var(--text-color-02)";

    if(form == "barber-form"){
        document.getElementById("first").style.background = "#232129";
        document.getElementById("first").style.color = "#666660";
    }else{
        document.getElementById("second").style.background = "#232129";
        document.getElementById("second").style.color = "#666660";
    }
}