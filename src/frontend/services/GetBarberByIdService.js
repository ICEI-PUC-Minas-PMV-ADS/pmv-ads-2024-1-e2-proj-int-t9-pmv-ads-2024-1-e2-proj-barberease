class GetBarberByIdService {
   
    
    static async getbyid(we) {
        let getByIdEndpoint=we;
          
      try {
        const response = await fetch(getByIdEndpoint, 
        {method: 'GET'}) ;
       
        return response.json();



      } catch (err) {
        console.error(`failed: ${JSON.stringify(err)}`);
        throw err;
      }
    }
  }