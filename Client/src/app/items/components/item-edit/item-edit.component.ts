import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ItemsService } from '../../items.service';
import { Item, IItem } from '../../models/Item';

@Component({
  selector: 'app-item-edit',
  templateUrl: './item-edit.component.html',
  styleUrls: ['./item-edit.component.css']
})
export class ItemEditComponent implements OnInit {
  itemId: any;
  item: IItem;
  constructor(private service: ItemsService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
    this.itemId = this.route.snapshot.paramMap.get('id');
    if (this.itemId) {
      console.log(`We have an id of ${this.itemId}`);
      this.service.getItemById(this.itemId).subscribe((result: IItem) => {
        this.item = result;
      });
    }
  }

  onUpdateItem(event: IItem) {
    this.service.updateItemById(event.id, event).subscribe((result: IItem) => {
      alert('Updated Sucessfully');
      this.item = result;
      this.router.navigate(['items', this.itemId]);
    }, (error) => {
      alert(error);
    });
  }

}
