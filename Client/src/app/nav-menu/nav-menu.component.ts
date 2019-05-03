import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../auth/auth.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {

  isExpanded = false;

  constructor(private auth: AuthService, private router: Router) { }

  ngOnInit() {
    this.isLoggedIn();
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
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
    this.router.navigate(['/auth']);
  }
}
