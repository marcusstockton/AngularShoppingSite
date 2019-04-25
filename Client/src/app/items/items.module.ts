import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ItemsDashboardComponent } from './containers/items-dashboard/items-dashboard.component';
import { ItemDetailComponent } from './components/item-detail/item-detail.component';
import { ItemFormComponent } from './components/item-form/item-form.component';
import { ItemViewerComponent } from './containers/item-viewer/item-viewer.component';
import { ReviewsModule } from '../reviews/reviews.module';
import { CoreModule } from '@angular/flex-layout';
import { ItemsTableComponent } from './components/items-table/items-table.component';
import {
  MatTableModule, MatPaginatorModule, MatSortModule, MatProgressSpinnerModule, MatFormFieldModule,
  MatInputModule,
  MatButtonModule
} from '@angular/material';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

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
    FormsModule,
    ReactiveFormsModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatProgressSpinnerModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
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
