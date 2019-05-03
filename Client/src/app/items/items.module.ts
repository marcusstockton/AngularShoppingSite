import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ItemsDashboardComponent } from './containers/items-dashboard/items-dashboard.component';
import { ItemDetailComponent } from './components/item-detail/item-detail.component';
import { ItemFormComponent } from './components/item-form/item-form.component';
import { ItemViewerComponent } from './containers/item-viewer/item-viewer.component';
import { ReviewsModule } from '../reviews/reviews.module';

import { ItemsTableComponent } from './components/items-table/items-table.component';

import { RouterModule } from '@angular/router';
import { CoreModule } from '../core/core.module';

@NgModule({
  declarations: [
    ItemsDashboardComponent,
    ItemDetailComponent,
    ItemFormComponent,
    ItemViewerComponent,
    ItemsTableComponent,
  ],
  imports: [
    CommonModule,
    ReviewsModule,
    CoreModule,
    RouterModule,
  ],
  exports: [
    ItemsDashboardComponent,
    ItemDetailComponent,
    ItemFormComponent,
    ItemViewerComponent,
    ItemsTableComponent,
  ]
})
export class ItemsModule { }
