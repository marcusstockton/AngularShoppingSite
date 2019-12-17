import axios from 'axios';
import { LoginModel } from './loginModel';
import router from '@/router';
import {Route} from 'vue-router'

const api = 'https://localhost:5001/api';

class AuthService {
    constructor() {
        console.log('creating new instance of auth.service');
    }
    public logIn(user: LoginModel) {
        return axios.post(`${api}/Users/authenticate`, user)
            .then((result) => {
                console.log(result.data);
                localStorage.setItem('access_token', JSON.stringify(result.data['token']));
                axios.defaults.headers.common['Authorization'] = result.data['token'];
                router.replace('/');
            }).catch((err) => {
                console.log(err);
            });
    }
    public logOut() {
        localStorage.removeItem('access_token');
        delete axios.defaults.headers.common['Authorization']
        if(window.location.pathname !== '/'){
            router.replace('/');
        }
        
    }
    public CurrentUser() {
        return localStorage.getItem('access_token') !== null;
    }
}

// Export a singleton instance in the global namespace
export const authService = new AuthService();