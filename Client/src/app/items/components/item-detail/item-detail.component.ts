import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ItemsService } from '../../items.service';
import { IItem, IItemDetails } from '../../models/Item';
import { MatSnackBar } from '@angular/material';
import { AuthService } from 'src/app/auth/auth.service';
import {environment} from '../../../../environments/environment';

@Component({
  selector: 'app-item-detail',
  templateUrl: './item-detail.component.html',
  styleUrls: ['./item-detail.component.css']
})
export class ItemDetailComponent implements OnInit {

  private itemId: string;
  item: IItemDetails;
  showAddReviewForm = false;
  addReviewButtonText = 'Add a Review';
  env = environment;

  constructor(private service: ItemsService,
              private route: ActivatedRoute,
              private router: Router,
              private snackBar: MatSnackBar,
              private auth: AuthService) { }

  ngOnInit() {
    this.itemId = this.route.snapshot.paramMap.get('id');

    this.service.getItemById(this.itemId).subscribe((result) => {
      this.item = result;
    }, (error) => {
      alert(error);
    });
  }

  delete(item: IItem) {
    let result = confirm('Are you sure to delete ' + item.name);
    if (result) {
      this.service.deleteItem(item.id).subscribe((result) => {
        this.snackBar.open('Item Deleted Sucessfully');
        this.router.navigate(['/items']);
      }, (error) => {
        console.log(error);
      });
    }
  }

  addReview() {
    this.showAddReviewForm = !this.showAddReviewForm;

    if (this.showAddReviewForm) {
      this.addReviewButtonText = 'Cancel this.';
    } else {
      this.addReviewButtonText = 'Add a Review';
    }
  }

  isLoggedIn(): boolean {
    let currentUser = this.auth.currentUserValue;
    if (currentUser) {
      return true;
    }
    return false;
  }

}
