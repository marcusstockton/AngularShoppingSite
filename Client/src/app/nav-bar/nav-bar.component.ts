import { Component } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Router } from '@angular/router';
import { AuthService } from '../auth/auth.service';
import { MatSnackBar } from '@angular/material';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent {

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches)
    );

  constructor(
    private breakpointObserver: BreakpointObserver,
    private auth: AuthService,
    private router: Router,
    private snackBar: MatSnackBar
    ) {
    this.isLoggedIn();
  }

  isLoggedIn(): boolean {
    let currentUser = this.auth.currentUserValue;
    if (currentUser) {
      return true;
    }
    return false;
  }

  signOut() {
    this.auth.logout();
    this.snackBar.open('Logged out sucessfully.', 'OK', {
      duration: 3000
    });
    this.router.navigate(['/']);
  }

}
