class AppointmentsService {
  static PROD_BASE_URL = 'https://barberease.azurewebsites.net';
  static LOCAL_BASE_URL = 'http://localhost:8000';

  static BASE_URL =
    ['localhost', '127.0.0.1'].includes(location.hostname)
      ? AppointmentsService.LOCAL_BASE_URL
      : AppointmentsService.PROD_BASE_URL;
  static APPOINTMENTS_PATH = `${AppointmentsService.BASE_URL}/api/Appointments`;

  static async getClientAppointments(clientId) {
    const endpoint = `${AppointmentsService.APPOINTMENTS_PATH}/details/${clientId}/client`;

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

  static async getEstablishmentAppointments(establishmentId) {
    const endpoint = `${AppointmentsService.APPOINTMENTS_PATH}/details/${establishmentId}/establishment`;

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

  static async updateStatus(id, updateStatusData) {
    const endpoint = `${AppointmentsService.APPOINTMENTS_PATH}/${id}/status`;

    try {
      const response = await fetch(endpoint, {
        method: 'PUT',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(updateStatusData),
      });

      if (!response.ok) {
        throw new Error(response.statusText);
      }
    } catch (err) {
      console.error(`Request failed: ${err.message}`);
      throw err;
    }
  }
}
