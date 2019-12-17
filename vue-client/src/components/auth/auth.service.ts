import axios from 'axios';
import { LoginModel } from './loginModel';

const api = 'https://localhost:5001/api';

class AuthService {
    constructor() {
        console.log('creating new instance of auth.service');
    }
    public logIn(user: LoginModel) {
        return axios.post(`${api}/Users/authenticate`, user)
            .then((result) => {
                console.log(result.data);
                localStorage.setItem('user-token', JSON.stringify(result.data['token']));
            }).catch((err) => {
                console.log(err);
            });
    }
    public logOut() {

    }
}

// Export a singleton instance in the global namespace
export const authService = new AuthService();