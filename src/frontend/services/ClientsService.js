class ClientsService {
  static BASE_URL = 'https://barberease.azurewebsites.net';
  static CLIENTS_PATH = `${AuthService.BASE_URL}/api/Clients`;

  static async getById(clientId) {
    const endpoint = `${AuthService.CLIENTS_PATH}/${clientId}`;

    try {
      const response = await fetch(endpoint);

      return await response.json();
    } catch (err) {
      console.error(`Request failed: ${JSON.stringify(err)}`);
      throw err;
    }
  }
}
