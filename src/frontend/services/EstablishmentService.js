class EstablishmentService {
  static PROD_BASE_URL = 'https://barberease.azurewebsites.net';
  static LOCAL_BASE_URL = 'http://localhost:8000';

  static BASE_URL =
    ['localhost', '127.0.0.1'].includes(location.hostname)
      ? EstablishmentService.LOCAL_BASE_URL
      : EstablishmentService.PROD_BASE_URL;
  static ESTABLISHMENT_PATH = `${EstablishmentService.BASE_URL}/api/Establishments`;

  static async getAll() {
    const endpoint = EstablishmentService.ESTABLISHMENT_PATH;

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

  static async getAllDetails() {
    const endpoint = `${EstablishmentService.ESTABLISHMENT_PATH}/details`;

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

  static async getById(establishmentId) {
    const endpoint = `${EstablishmentService.ESTABLISHMENT_PATH}/${establishmentId}`;

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

  static async updateById(establishmentId, updateData) {
    const endpoint = `${EstablishmentService.ESTABLISHMENT_PATH}/${establishmentId}`;

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
    const endpoint = EstablishmentService.ESTABLISHMENT_PATH;

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
