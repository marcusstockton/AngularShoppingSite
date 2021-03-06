import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpErrorResponse } from '@angular/common/http';
import { AuthService } from 'src/app/auth/auth.service';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { MatSnackBar } from '@angular/material';
import { Router } from '@angular/router';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
    constructor(private authenticationService: AuthService, private snackBar: MatSnackBar, private router: Router) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(request).pipe(catchError(err => {
            if (err.status === 401) {
                // auto logout if 401 response returned from api
                this.authenticationService.logout();
                this.snackBar.open(err.statusText);
                // location.reload(true);
                this.router.navigate(['/auth']);
            }
            var error = "";
            if(err instanceof HttpErrorResponse){
                if(err.status === 415){
                    error = err.error.title;
                } else{
                    error = err.error;
                }
            }
            else{
                error = err.error.message || err.statusText;
            }
            // const error = err.error.message || err.statusText;
            return throwError(error);
        }));
    }
}