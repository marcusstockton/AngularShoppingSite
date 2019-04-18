import { Injectable, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ItemsService implements OnInit {

  private baseURL = environment.apiBaseURL + 'Items';
  constructor(private httpClient: HttpClient) { }

  ngOnInit(): void {
    this.getItems();
  }

  getItems(): Observable<any[]>{
    return this.httpClient.get<any[]>(`${this.baseURL}`)
      .pipe(
        tap( // Log the result or error
          // data => console.log(data),
          // error => console.log(error)
        )
      );
  }
}
