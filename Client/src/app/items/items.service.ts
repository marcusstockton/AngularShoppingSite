import { Injectable, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { IItem } from './models/Item';

@Injectable({
  providedIn: 'root'
})
export class ItemsService implements OnInit {

  private baseURL = environment.apiBaseURL + 'Items';
  constructor(private httpClient: HttpClient) { }

  ngOnInit(): void {
    this.getItems();
  }

  getItems(): Observable<IItem[]> {
    return this.httpClient.get<any[]>(`${this.baseURL}`)
      .pipe(
        tap( // Log the result or error
          // data => console.log(data),
          // error => console.log(error)
        )
      );
  }

  getItemById(id: any): Observable<IItem> {
    return this.httpClient.get<any>(`${this.baseURL}/${id}`)
      .pipe(
        tap( // Log the result or error
          // data => console.log(data),
          // error => console.log(error)
        )
      );
  }

  updateItemById(id: any, body: IItem): Observable<IItem> {
    return this.httpClient.put<any>(`${this.baseURL}/${id}`, body)
      .pipe(
        tap( // Log the result or error
          // data => console.log(data),
          // error => console.log(error)
        )
      );
  }

  createItem(body: IItem): Observable<IItem> {
    const config = new HttpHeaders().set('Content-Type', 'application/json')
                                .set('Accept', 'application/json');
    return this.httpClient.post<any>(`${this.baseURL}`, body,{ headers: config })
      .pipe(
        tap( // Log the result or error
          // data => console.log(data),
          // error => console.log(error)
        )
      );
  }

}
