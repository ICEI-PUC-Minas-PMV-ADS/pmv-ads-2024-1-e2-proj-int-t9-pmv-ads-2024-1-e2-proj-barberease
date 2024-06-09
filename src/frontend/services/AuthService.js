class AuthService {
  static BASE_URL = 'http://localhost:8000';
  static AUTH_PATH = `${AuthService.BASE_URL}/api/Auth`;

  static async login(loginData) {
    const loginEndpoint = `${AuthService.AUTH_PATH}/Login`;

    try
   {
      const response = await fetch(loginEndpoint, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(loginData),
      });

      return response.json();
    } catch (err) {
      console.error(`Login failed: ${JSON.stringify(err)}`);
      throw err;
    }
  }
}
