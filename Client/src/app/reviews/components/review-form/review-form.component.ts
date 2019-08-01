import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { IReview } from '../../models/review';

@Component({
  selector: 'app-review-form',
  templateUrl: './review-form.component.html',
  styleUrls: ['./review-form.component.css']
})
export class ReviewFormComponent implements OnInit {

  reviewForm: FormGroup;
  review: IReview;

  constructor(private fb: FormBuilder) {
    this.reviewForm = this.createFormComponent();
   }

  ngOnInit() {
  }

  createFormComponent() {
    return this.fb.group({
      title: [''],
      rating: [''],
      description: [''],
    });
  }

  onSubmit() {
    console.log(this.reviewForm.value);
  }
}
