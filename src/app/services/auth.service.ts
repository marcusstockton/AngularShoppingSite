import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import * as jwt_decode from 'jwt-decode';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private baseURL = environment.apiBaseURL;
  private cookieName = "currentUser";

  constructor(private http: HttpClient, private router: Router) { }

  login(username: string, password: string, accountType: number) {
    return this.http.post<any>(`${this.baseURL}AuthenticateUser`, { UserName: username, Password: password, AccountType: accountType })
      .pipe(map(user => {
        if (user) {
          localStorage.setItem(this.cookieName, JSON.stringify(user));
        }
        return user;
      }));
  }

  logout() {
    localStorage.removeItem(this.cookieName);
  }

  isAuthenticated(): boolean {
    let decoded = this.readCookie(this.cookieName);
    if(decoded){
      var utcSeconds = decoded.exp;
      var d = new Date(0); // set the date to the epoch
      d.setUTCSeconds(utcSeconds);
      if(d > new Date()){
        return true;
      }
      localStorage.removeItem(this.cookieName);
      return false;
    }
  }

  private readCookie(cookieName: string){
    let token = localStorage.getItem(cookieName);
    if(!token){
      return null;
    }
    return jwt_decode(token);
  }
}
