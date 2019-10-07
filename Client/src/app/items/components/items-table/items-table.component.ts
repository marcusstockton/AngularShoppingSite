import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { ItemsService } from '../../items.service';
import { IItem } from '../../models/Item';
import { Router } from '@angular/router';

@Component({
  selector: 'app-items-table',
  templateUrl: './items-table.component.html',
  styleUrls: ['./items-table.component.css']
})
export class ItemsTableComponent implements AfterViewInit {
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  dataSource: MatTableDataSource<IItem>;
  ItemList: IItem[]  = [];

  constructor(private service: ItemsService, private router: Router) {
    this.service.getItems().subscribe((result: IItem[]) => {
      this.dataSource = new MatTableDataSource(result);
    }, (error) => {
      console.log(error.statusText);
    });
  }

  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns = ['Name', 'Title', 'Description', 'Price', 'CreatedDate'];

  ngAfterViewInit() {
    setTimeout(() => {
      if (this.dataSource) {
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      }
    });
  }

  applyFilter(filterValue: string) {
    filterValue = filterValue.trim(); // Remove whitespace
    filterValue = filterValue.toLowerCase(); // Datasource defaults to lowercase matches
    this.dataSource.filter = filterValue;
  }

  selectRow(row: IItem) {
    console.log(row);
    this.router.navigate([`items/${row.id}`]);
  }
}
