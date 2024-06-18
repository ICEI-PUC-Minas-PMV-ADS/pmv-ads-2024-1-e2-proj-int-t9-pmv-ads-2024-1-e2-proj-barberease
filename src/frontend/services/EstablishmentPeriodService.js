class EstablishmentPeriodService {
  static PROD_BASE_URL = 'https://barberease.azurewebsites.net';
  static LOCAL_BASE_URL = 'http://localhost:8000';

  static BASE_URL =
    ['localhost', '127.0.0.1'].includes(location.hostname)
      ? EstablishmentPeriodService.LOCAL_BASE_URL
      : EstablishmentPeriodService.PROD_BASE_URL;
  static ESTABLISHMENT_PERIOD_PATH = `${EstablishmentPeriodService.BASE_URL}/api/EstablishmentPeriods`;

  static async getEstablishmentPeriods(establishmentId) {
    const endpoint = `${EstablishmentPeriodService.ESTABLISHMENT_PERIOD_PATH}/${establishmentId}/establishment`;

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

  static async updateById(periodId, updateData) {
    const endpoint = `${EstablishmentPeriodService.ESTABLISHMENT_PERIOD_PATH}/${periodId}`;

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

  static async deleteById(periodId) {
    const endpoint = `${EstablishmentPeriodService.ESTABLISHMENT_PERIOD_PATH}/${periodId}`;

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
    const endpoint = EstablishmentPeriodService.ESTABLISHMENT_PERIOD_PATH;

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
