import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { AuthService } from './auth.service';
import { MatSnackBar } from '@angular/material';
import { HttpErrorResponse } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.css']
})
export class AuthComponent implements OnInit {

  registerErrorList: any[] = [];
  loginErrorList: string[] = [];
  returnUrl: string;

  loginForm: FormGroup = new FormGroup({
    username: new FormControl(''),
    password: new FormControl(''),
  });

registerForm: FormGroup = new FormGroup({
    username: new FormControl(''),
    password: new FormControl(''),
    firstName: new FormControl(''),
    lastName: new FormControl(''),
    dob: new FormControl(''),
  });

  constructor(private service: AuthService, private snackBar: MatSnackBar, private route: ActivatedRoute, private router: Router) {
  }

  ngOnInit() {

    // get return url from route parameters or default to '/'
    this.returnUrl = this.route.snapshot.queryParams.get('returnUrl') || '/';
  }

  login() {
    if (this.loginForm.valid) {
      this.service.login(this.loginForm.value).subscribe((result) => {
        this.snackBar.open(result);
        this.router.navigateByUrl(this.returnUrl);
      }, (error) => {
        if (error.error.length > 1) {
          this.loginErrorList = [];
          for (let err of error.error) {
            this.loginErrorList.push(err.description);
          }
          alert(this.loginErrorList.join('\n'));
        } else {
          this.snackBar.open(error.statusText);
        }
      });
    }
  }

  register() {
    if (this.registerForm.valid) {
      this.registerErrorList = [];
      this.service.register(this.registerForm.value).subscribe((result) => {
        this.snackBar.open(result);
      }, (error: HttpErrorResponse) => {
        if (error.error.length > 1) {
          for (let err of error.error) {
            this.registerErrorList.push(err.description);
          }
          alert(this.registerErrorList.join("\n"))
        } else {
          this.snackBar.open(error.statusText);
        }
      });
    }
  }

}
