import { DataSource, CollectionViewer } from '@angular/cdk/collections';
import { MatPaginator, MatSort } from '@angular/material';
import { map } from 'rxjs/operators';
import { Observable, of as observableOf, merge, BehaviorSubject } from 'rxjs';
import { ItemsService } from '../../items.service';
import { IItem } from '../../models/Item';


/**
 * Data source for the ItemsTable view. This class should
 * encapsulate all logic for fetching and manipulating the displayed data
 * (including sorting, pagination, and filtering).
 */
export class ItemsTableDataSource extends DataSource<IItem> {
  data: IItem[];

  private lessonsSubject = new BehaviorSubject<IItem[]>([]);
  private loadingSubject = new BehaviorSubject<boolean>(false);
  public loading$ = this.loadingSubject.asObservable();

  constructor(private paginator: MatPaginator, private sort: MatSort, private service: ItemsService) {
    super();
  }

  /**
   * Connect this data source to the table. The table will only update when
   * the returned stream emits new items.
   * @returns A stream of the items to be rendered.
   */
  connect(collectionViewer: CollectionViewer): Observable<IItem[]> {
    return this.service.getItems();
  }

  /**
   *  Called when the table is being destroyed. Use this function, to clean up
   * any open connections or free any held resources that were set up during connect.
   */
  disconnect() {
    this.lessonsSubject.complete();
  }

  /**
   * Paginate the data (client-side). If you're using server-side pagination,
   * this would be replaced by requesting the appropriate data from the server.
   */
  private getPagedData(data: IItem[]) {
    const startIndex = this.paginator.pageIndex * this.paginator.pageSize;
    return data.splice(startIndex, this.paginator.pageSize);
  }

  /**
   * Sort the data (client-side). If you're using server-side sorting,
   * this would be replaced by requesting the appropriate data from the server.
   */
  private getSortedData(data: IItem[]) {
    if (!this.sort.active || this.sort.direction === '') {
      return data;
    }

    // return data.sort((a, b) => {
    //   const isAsc = this.sort.direction === 'asc';
    //   switch (this.sort.active) {
    //     case 'name': return compare(a.name, b.name, isAsc);
    //     case 'id': return compare(+a.id, +b.id, isAsc);
    //     default: return 0;
    //   }
    // });
  }
}

/** Simple sort comparator for example ID/Name columns (for client-side sorting). */
function compare(a, b, isAsc) {
  return (a < b ? -1 : 1) * (isAsc ? 1 : -1);
}
