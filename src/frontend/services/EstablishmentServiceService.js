class EstablishmentServiceService {
  static PROD_BASE_URL = 'https://barberease.azurewebsites.net';
  static LOCAL_BASE_URL = 'http://localhost:8000';

  static BASE_URL =
    ['localhost', '127.0.0.1'].includes(location.hostname)
      ? EstablishmentServiceService.LOCAL_BASE_URL
      : EstablishmentServiceService.PROD_BASE_URL;
  static ESTABLISHMENT_SERVICE_PATH = `${EstablishmentServiceService.BASE_URL}/api/EstablishmentServices`;

  static async getEstablishmentServices(establishmentId) {
    const endpoint = `${EstablishmentServiceService.ESTABLISHMENT_SERVICE_PATH}/${establishmentId}/establishment`;

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

  static async updateById(serviceId, updateData) {
    const endpoint = `${EstablishmentServiceService.ESTABLISHMENT_SERVICE_PATH}/${serviceId}`;

    try {
      const response = await fetch(endpoint, {
        method: 'PUT',
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

  static async deleteById(serviceId) {
    const endpoint = `${EstablishmentServiceService.ESTABLISHMENT_SERVICE_PATH}/${serviceId}`;

    try {
      const response = await fetch(endpoint, { method: 'DELETE' });

      if (!response.ok) {
        throw new Error(response.statusText);
      }
    } catch (err) {
      console.error(`Request failed: ${JSON.stringify(err)}`);
      throw err;
    }
  }

  static async create(createData) {
    const endpoint = EstablishmentServiceService.ESTABLISHMENT_SERVICE_PATH;

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
      console.error(`Request failed: ${JSON.stringify(err)}`);
      throw err;
    }
  }
}
