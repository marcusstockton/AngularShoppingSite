import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IReview } from './models/review';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ReviewService {

  private baseURL = environment.apiBaseURL + 'Reviews';
  
  constructor(private httpClient: HttpClient) { }

  createReview(body: IReview): Observable<IReview> {
    const formData: FormData = new FormData();
    
    formData.append('review', JSON.stringify(body));

    return this.httpClient.post<any>(`${this.baseURL}`, formData)
      .pipe(
        tap( // Log the result or error
          // data => console.log(data),
          // error => console.log(error)
        )
      );
  }
}
