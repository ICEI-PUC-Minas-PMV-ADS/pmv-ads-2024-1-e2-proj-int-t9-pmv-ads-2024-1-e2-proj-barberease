class AuthService {
  static PROD_BASE_URL = 'https://barberease.azurewebsites.net';
  static LOCAL_BASE_URL = 'http://localhost:8000';

  static BASE_URL =
    ['localhost', '127.0.0.1'].includes(location.hostname)
      ? AuthService.LOCAL_BASE_URL
      : AuthService.PROD_BASE_URL;
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
