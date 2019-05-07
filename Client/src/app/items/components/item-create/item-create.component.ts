import { Component, OnInit } from '@angular/core';
import { IItem } from '../../models/Item';
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

  onCreateItem(item: IItem) {
    this.service.createItem(item).subscribe((result) => {
      alert(JSON.stringify(result) + ' record(s) updated!' );
      this.router.navigate(['items']);
    }, (error) => {
      alert(error);
    });
  }

}
