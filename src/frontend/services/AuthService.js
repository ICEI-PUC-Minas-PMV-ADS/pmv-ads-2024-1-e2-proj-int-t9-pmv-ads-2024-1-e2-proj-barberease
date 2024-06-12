class AuthService {
  static BASE_URL = 'https://barberease.azurewebsites.net';
  static AUTH_PATH = `${AuthService.BASE_URL}/api/Auth`;

  static async login(loginData) {
    const endpoint = `${AuthService.AUTH_PATH}/Login`;

    try {
      const response = await fetch(endpoint, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(loginData),
      });

      return await response.json();
    } catch (err) {
      console.error(`Request failed: ${JSON.stringify(err)}`);
      throw err;
    }
  }
}
