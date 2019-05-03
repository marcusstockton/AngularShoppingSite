import { Component } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Router } from '@angular/router';
import { AuthService } from '../auth/auth.service';

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

  constructor(private breakpointObserver: BreakpointObserver, private auth: AuthService, private router: Router) {
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
    this.router.navigate(['/']);
  }

}
