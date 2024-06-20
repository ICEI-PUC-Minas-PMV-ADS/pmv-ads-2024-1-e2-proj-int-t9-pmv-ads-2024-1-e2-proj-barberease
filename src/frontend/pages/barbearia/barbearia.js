
const we = localStorage.getItem('barber')

async function barberId()
{
    
    try{
    
    const databarber= await GetBarberByIdService.getbyid(we);
     document.getElementById('1dd').innerText= databarber.companyName;
     
     document.getElementById('1bb').innerText= databarber.address +", "+ databarber.city +"- "+databarber.state;
     const htmlbase = document.getElementById("abcd").innerHTML;
     let lista = document.getElementById("ServList");
     for (let i=0;i<3;++i)
        {   
            const li= document.createElement('li');
            li.innerHTML=htmlbase;
            document.getElementById("name").setAttribute("id","c"+i)
            document.getElementById("val").setAttribute("id","d"+i)
            document.getElementById("c"+i).innerText= databarber.establishmentServices[i].name; 
            document.getElementById("d"+i).innerText= "R$ "+ databarber.establishmentServices[i].price;
            
            lista.appendChild(li);
        }
        lista.removeChild(lista.lastChild)

        
    return
    }
    
    catch (err) {
        console.error(` failed: ${JSON.stringify(err)}`);
        throw err;
    }
    
}