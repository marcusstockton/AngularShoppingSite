import { Component, OnInit } from '@angular/core';
import { IItem } from '../../models/Item';
import { ItemsService } from '../../items.service';

@Component({
  selector: 'app-item-create',
  templateUrl: './item-create.component.html',
  styleUrls: ['./item-create.component.css']
})
export class ItemCreateComponent implements OnInit {

  constructor(private service: ItemsService) { }

  ngOnInit() {
  }

  onCreateItem(event: IItem) {
    alert(JSON.stringify(event));
    // TODO: Add in create to service call etc.
  }

}
