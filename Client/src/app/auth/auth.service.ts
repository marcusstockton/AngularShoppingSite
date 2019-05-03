import { Injectable, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService implements OnInit {

  private baseURL = environment.apiBaseURL + 'Users';
  constructor(private httpClient: HttpClient) { }

  ngOnInit(): void { }

    login(body: any): Observable<any> {
        let headers = new HttpHeaders();
        headers.set('Content-Type', 'application/json');

        return this.httpClient.post<any>(`${this.baseURL}/authenticate`, body, { headers: headers })
            .pipe(
                tap( // Log the result or error
                    // data => console.log(data),
                    // error => console.log(error)
                )
            );
    }

    register(body: any): Observable<any> {
      let headers = new HttpHeaders();
      headers.set('Content-Type', 'application/json');

      return this.httpClient.post<any>(`${this.baseURL}/register`, body, { headers: headers })
          .pipe(
              tap( // Log the result or error
                  // data => console.log(data),
                  // error => console.log(error)
              )
          );
  }

}
