import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ItemsService } from '../../items.service';
import { IItem, IItemDetails } from '../../models/Item';

@Component({
  selector: 'app-item-edit',
  templateUrl: './item-edit.component.html',
  styleUrls: ['./item-edit.component.css']
})
export class ItemEditComponent implements OnInit {
  itemId: any;
  item: IItemDetails;
  constructor(private service: ItemsService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
    this.itemId = this.route.snapshot.paramMap.get('id');
    if (this.itemId) {
      console.log(`We have an id of ${this.itemId}`);
      this.service.getItemById(this.itemId).subscribe((result: IItemDetails) => {
        this.item = result;
      });
    }
  }

  onUpdateItem(item: IItem) {
    this.service.updateItemById(item.id, item).subscribe((result: IItem) => {
      alert('Updated Sucessfully');
      this.router.navigate(['items', this.itemId]);
    }, (error) => {
      alert(error);
    });
  }

}
