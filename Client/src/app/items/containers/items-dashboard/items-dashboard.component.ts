import { Component, OnInit } from '@angular/core';
import { ItemsService } from '../../items.service';

@Component({
  selector: 'app-items-dashboard',
  templateUrl: './items-dashboard.component.html',
  styleUrls: ['./items-dashboard.component.css']
})
export class ItemsDashboardComponent implements OnInit {
  public itemList;
  public displayedColumns: string[];
  constructor() { }

  ngOnInit() {
  }

}
