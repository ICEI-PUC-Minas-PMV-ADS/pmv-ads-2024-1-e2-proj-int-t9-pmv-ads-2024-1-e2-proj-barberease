class ClientsService {
  static PROD_BASE_URL = 'https://barberease.azurewebsites.net';
  static LOCAL_BASE_URL = 'http://localhost:8000';

  static BASE_URL =
    ['localhost', '127.0.0.1'].includes(location.hostname)
      ? ClientsService.LOCAL_BASE_URL
      : ClientsService.PROD_BASE_URL;
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
      console.error(`Request failed: ${err.message}`);
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
      console.error(`Request failed: ${err.message}`);
      throw err;
    }
  }

  static async create(createData) {
    const endpoint = ClientsService.CLIENTS_PATH;

    try {
      const response = await fetch(endpoint, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(createData),
      });

      if (!response.ok) {
        throw new Error(response.statusText);
      }

      return await response.json();
    } catch (err) {
      console.error(`Request failed: ${err.message}`);
      throw err;
    }
  }
}
