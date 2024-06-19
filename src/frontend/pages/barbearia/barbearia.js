
const we = localStorage.getItem('barber')

async function barberId()
{
    
    try{
    
    const databarber= await GetBarberByIdService.getbyid(we);
     document.getElementById('1dd').innerText= databarber.companyName;
     document.getElementById('1bb').innerText= databarber.address +", "+ databarber.city +"- "+databarber.state;
    return ;
    }
    
    catch (err) {
        console.error(`Login failed: ${JSON.stringify(err)}`);
        throw err;
    }
    
}