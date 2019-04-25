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
    title: [''],

  });

  constructor(private service: ItemsService, private route: ActivatedRoute, private fb: FormBuilder) { }

  ngOnInit() {
    this.itemId = this.route.snapshot.paramMap.get('id');
    if (this.itemId) {
      console.log(`We have an id of ${this.itemId}`);
      // Go get the data...
    }
  }

  onSubmit() {
    // TODO: Use EventEmitter with form value
    console.warn(this.itemForm.value);
  }
}
