import { Component, OnInit } from '@angular/core';
import { IItem, IItemCreate } from '../../models/Item';
import { ItemsService } from '../../items.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-item-create',
  templateUrl: './item-create.component.html',
  styleUrls: ['./item-create.component.css']
})
export class ItemCreateComponent implements OnInit {

  constructor(private service: ItemsService, private router: Router) { }

  ngOnInit() {
  }

  onCreateItem(item: IItemCreate) {
    this.service.createItem(item).subscribe((result) => {
      this.router.navigate(['items', result.id]);
    }, (error) => {
      alert(error);
    });
  }

}
