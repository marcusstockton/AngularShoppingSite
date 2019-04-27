import { Component, OnInit, Input } from '@angular/core';
import { IItem } from '../../models/Item';
import { ItemsService } from '../../items.service';
import { ActivatedRoute } from '@angular/router';
import { FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-item-form',
  templateUrl: './item-form.component.html',
  styleUrls: ['./item-form.component.css']
})
export class ItemFormComponent implements OnInit {
  itemId: string;
  item: IItem;
  itemForm = this.fb.group({
    id: [''],
    title: [''],
    name: [''],
    description: [''],
    price: [''],
    createdDate: [''],
    updatedDate: [''],
  });

  constructor(private service: ItemsService, private route: ActivatedRoute, private fb: FormBuilder) { }

  ngOnInit() {
    this.itemId = this.route.snapshot.paramMap.get('id');
    if (this.itemId) {
      console.log(`We have an id of ${this.itemId}`);
      // Go get the data...
      // this.service.getItemById(this.itemId).pipe(map((result) => {
      //   this.item = result;
      // }));
      this.service.getItemById(this.itemId).subscribe((result) => {
        // Set the form data:
        this.itemForm.patchValue(
          {title: result.title,
            description: result.description,
            price: result.price,
            id: result.id,
            createdDate: result.createdDate,
            updatedDate: result.updatedDate,
            name: result.name
          });
      });
    }
  }

  onSubmit() {
    if (this.itemForm.valid) {
      if (this.itemId) {
        // Its an update, so put
        this.service.updateItemById(this.itemId, this.itemForm.value).subscribe((result) => {
          alert('Sucessfully updated!');
        }, (error) => {
          alert('There was an error updating the item: ' + error.error);
        });

      } else {
        // Its new, so post
      }
    } else {
      // Form has errors:
    }

  }
}
