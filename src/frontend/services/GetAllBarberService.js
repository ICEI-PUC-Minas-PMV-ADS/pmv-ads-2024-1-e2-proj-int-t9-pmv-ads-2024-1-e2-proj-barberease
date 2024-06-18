class GetAllBarberService {
  static PROD_BASE_URL = 'https://barberease.azurewebsites.net';
  static LOCAL_BASE_URL = 'http://localhost:8000';

  static BASE_URL =
    ['localhost', '127.0.0.1'].includes(location.hostname)
      ? GetAllBarberService.LOCAL_BASE_URL
      : GetAllBarberService.PROD_BASE_URL;
  static GETALL_PATH = `${GetAllBarberService.BASE_URL}/api/Establishments`;

  static async getall() {
    const getallEndpoint = `${this.GETALL_PATH}/`;

    try {
      const response = await fetch(getallEndpoint,
        { method: 'GET' });

      return response.json();



    } catch (err) {
      console.error(`Login failed: ${JSON.stringify(err)}`);
      throw err;
    }
  }
}
