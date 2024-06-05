const clientForm = document.getElementById('client-form');
const barberForm = document.getElementById('barber-form');

clientForm.addEventListener('submit', submitClientForm);
barberForm.addEventListener('submit', submitBarberForm);

async function submitClientForm(event) {
    event.preventDefault();

    const targetForm = event.target;
    const formData = new FormData(targetForm);

    const cep = formData.get('cep');

    const url = `http://viacep.com.br/ws/${cep}/json/`
    const dados = await fetch(url);
    const endereco = await dados.json();

    const name = formData.get('name');
    const phone = formData.get('telephone');
    const email = formData.get('email');
    const password = formData.get('password');
    const number = formData.get('number');
    const city = endereco.localidade;
    const uf = endereco.uf;
}

async function submitBarberForm(event) {
    event.preventDefault();

    const targetForm = event.target;
    const formData = new FormData(targetForm);

    const cep = formData.get('cep');

    const url = `http://viacep.com.br/ws/${cep}/json/`
    const dados = await fetch(url);
    const endereco = await dados.json();

    const razao = formData.get('razao');
    const name = formData.get('name');
    const cnpj = formData.get('cnpj');
    const phone = formData.get('telephone');
    const email = formData.get('email');
    const password = formData.get('password');
    const number = formData.get('number');
    const city = endereco.localidade;
    const uf = endereco.uf;
}

//Functions

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