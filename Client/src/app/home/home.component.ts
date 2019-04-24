import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  private baseURL = environment.apiBaseURL;
  public animalControl;
  public selectFormControl;
  public animals: any[] = [];

  constructor(private httpClient: HttpClient) {
    this.animalControl = new FormControl('', [Validators.required]);
    this.selectFormControl = new FormControl('', Validators.required);
    this.animals = [
      {name: 'Dog', sound: 'Woof!'},
      {name: 'Cat', sound: 'Meow!'},
      {name: 'Cow', sound: 'Moo!'},
      {name: 'Fox', sound: 'Wa-pa-pa-pa-pa-pa-pow!'},
    ];
  }

  ngOnInit() {
    // Test that calling the back end works:
    this.httpClient.get(this.baseURL + 'values').subscribe((res)=>{
      console.log(res);
    });
  }

  

  
}
