import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { MatPaginator, MatSort } from '@angular/material';
import { ItemsTableDataSource } from './items-table-datasource';
import { ItemsService } from '../../items.service';

@Component({
  selector: 'app-items-table',
  templateUrl: './items-table.component.html',
  styleUrls: ['./items-table.component.css']
})
export class ItemsTableComponent implements AfterViewInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  dataSource: ItemsTableDataSource;

  constructor(private service: ItemsService) { }

  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns = ['Name', 'Title', 'Description', 'Price', 'CreatedDate'];

  ngAfterViewInit() {
    this.dataSource = new ItemsTableDataSource(this.paginator, this.sort, this.service);
  }

  selectRow(row) {
    console.log(row);
  }
}
