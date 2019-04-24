import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ItemsService } from '../../items.service';
import { IItem } from '../../models/Item';

@Component({
  selector: 'app-item-detail',
  templateUrl: './item-detail.component.html',
  styleUrls: ['./item-detail.component.css']
})
export class ItemDetailComponent implements OnInit {

  private itemId: string;
  item: IItem;
  constructor(private service: ItemsService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.itemId = this.route.snapshot.paramMap.get('id');
    console.log(`Item ID is ${this.itemId}`);

    this.service.getItemById(this.itemId).subscribe((result) => {
      this.item = result;
    }, (error) => {
      alert(error);
    });
  }

}
