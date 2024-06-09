class GetAllBarberService {
    static BASE_URL = 'https://barberease.azurewebsites.net';
    static GETALL_PATH = `${GetAllBarberService.BASE_URL}/api/Establishments`;
  
    static async getall() {
        const getallEndpoint = `${this.GETALL_PATH}/`;
  
      try {
        const response = await fetch(getallEndpoint, 
        {method: 'GET'}) ;
       
        return response.json();



      } catch (err) {
        console.error(`Login failed: ${JSON.stringify(err)}`);
        throw err;
      }
    }
  }