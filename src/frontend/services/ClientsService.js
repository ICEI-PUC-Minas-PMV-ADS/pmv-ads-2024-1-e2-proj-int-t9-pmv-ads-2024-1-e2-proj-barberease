class ClientsService {
  static BASE_URL = 'https://barberease.azurewebsites.net';
  static CLIENTS_PATH = `${ClientsService.BASE_URL}/api/Clients`;

  static async getById(clientId) {
    const endpoint = `${ClientsService.CLIENTS_PATH}/${clientId}`;

    try {
      const response = await fetch(endpoint);

      if (!response.ok) {
        throw new Error(response.statusText);
      }

      return await response.json();
    } catch (err) {
      console.error(`Request failed: ${JSON.stringify(err)}`);
      throw err;
    }
  }

  static async updateById(clientId, updateData) {
    const endpoint = `${ClientsService.CLIENTS_PATH}/${clientId}`;

    try {
      const response = await fetch(endpoint, {
        method: 'PATCH',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(updateData),
      });

      if (!response.ok) {
        throw new Error(response.statusText);
      }
    } catch (err) {
      console.error(`Request failed: ${JSON.stringify(err)}`);
      throw err;
    }
  }
}
