async function barber()
{
    try{
    const response = await GetAllBarberService.getall();
    const list=response;
    

         const hghghg = document.getElementById("card").innerHTML;
        let lista = document.getElementById("myList");
       for (let i=0;i<list.length;++i)
          {   
       
       
       const li= document.createElement('li');
            li.innerHTML=hghghg
            document.getElementById("123").setAttribute("id","c"+i)
            document.getElementById("345").setAttribute("id","d"+i)
            document.getElementById("901").setAttribute("id","e"+i)
            document.getElementById("c"+i).innerText= response[i].companyName; 
            document.getElementById("d"+i).innerText=response[i].phone;
            document.getElementById("e"+i).innerText= response[i].address+ ". " + response[i].city+ " - "+response[i].state
            lista.appendChild(li);
          }
        lista.removeChild(lista.lastChild)

          
        
          
           
        
    return ;
    }
    
    catch (err) {
        console.error(`Login failed: ${JSON.stringify(err)}`);
        throw err;
    }
    
}

