import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrdersDashboardComponent } from './containers/orders-dashboard/orders-dashboard.component';
import { OrderDetailComponent } from './components/order-detail/order-detail.component';
import { OrderFormComponent } from './components/order-form/order-form.component';
import { OrdersViewerComponent } from './containers/orders-viewer/orders-viewer.component';

@NgModule({
  declarations: [
    OrdersDashboardComponent,
    OrderDetailComponent,
    OrderFormComponent,
    OrdersViewerComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    OrdersDashboardComponent,
    OrderDetailComponent,
    OrderFormComponent,
    OrdersViewerComponent
  ]
})
export class OrdersModule { }
