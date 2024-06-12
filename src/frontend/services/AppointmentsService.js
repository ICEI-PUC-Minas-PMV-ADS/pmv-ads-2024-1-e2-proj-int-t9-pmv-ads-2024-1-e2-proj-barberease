class AppointmentsService {
  static BASE_URL = 'http://localhost:8000';
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
      console.error(`Request failed: ${JSON.stringify(err)}`);
      throw err;
    }
  }
}
