import { Injectable, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { IItem, IItemCreate, IItemDetails } from './models/Item';

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

  getItemById(id: any): Observable<IItemDetails> {
    return this.httpClient.get<any>(`${this.baseURL}/${id}`)
      .pipe(
        tap( // Log the result or error
          // data => console.log(data),
          // error => console.log(error)
        )
      );
  }

  updateItemById(id: any, body: IItem): Observable<IItem> {
    // const config = new HttpHeaders().set('Accept', 'application/json');

    const formData: FormData = new FormData();
    if (body.images.length > 0) {
      for (let image of body.images) {
        formData.append('fileArray', image, image.name);
      }
    }
     formData.append('item', JSON.stringify(body));

    return this.httpClient.put<any>(`${this.baseURL}/${id}`, formData)
      .pipe(
        tap( // Log the result or error
          // data => console.log(data),
          // error => console.log(error)
        )
      );
  }

  createItem(body: IItemCreate): Observable<IItem> {
    const config = new HttpHeaders().set('Content-Type', 'application/json').set('Accept', 'application/json');
    return this.httpClient.post<any>(`${this.baseURL}`, body, { headers: config })
      .pipe(
        tap( // Log the result or error
          // data => console.log(data),
          // error => console.log(error)
        )
      );
  }

  deleteItem(id: string): Observable<any>{
    const config = new HttpHeaders().set('Content-Type', 'application/json')
    .set('Accept', 'application/json');
    return this.httpClient.delete<any>(`${this.baseURL}/${id}`, { headers: config })
      .pipe(
        tap( // Log the result or error
          // data => console.log(data),
          // error => console.log(error)
        )
      );
  }

}
