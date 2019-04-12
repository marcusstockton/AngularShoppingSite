import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthComponent } from './auth/auth.component';
import { ErrorInterceptorComponent } from './helpers/error-interceptor/error-interceptor.component';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HttpClientModule } from '@angular/common/http';
import { NotFoundComponent } from './not-found.component';
import { AccountDashboardComponent } from './account-dashboard/containers/account-dashboard/account-dashboard.component';
import { ItemsDashboardComponent } from './items/containers/items-dashboard/items-dashboard.component';
import { ItemViewerComponent } from './items/containers/item-viewer/item-viewer.component';
import { AccountViewerComponent } from './account-dashboard/containers/account-viewer/account-viewer.component';
import { AccountFormComponent } from './account-dashboard/components/account-form/account-form.component';
import { AccountDetailComponent } from './account-dashboard/components/account-detail/account-detail.component';
import { ItemFormComponent } from './items/components/item-form/item-form.component';
import { ItemDetailComponent } from './items/components/item-detail/item-detail.component';
import { OrdersDashboardComponent } from './orders/containers/orders-dashboard/orders-dashboard.component';
import { OrdersViewerComponent } from './orders/containers/orders-viewer/orders-viewer.component';
import { OrderFormComponent } from './orders/components/order-form/order-form.component';
import { OrderDetailComponent } from './orders/components/order-detail/order-detail.component';
import { ReviewsDashboardComponent } from './reviews/containers/reviews-dashboard/reviews-dashboard.component';
import { ReviewViewerComponent } from './reviews/containers/review-viewer/review-viewer.component';
import { ReviewDetailComponent } from './reviews/components/review-detail/review-detail.component';
import { ReviewFormComponent } from './reviews/components/review-form/review-form.component';

@NgModule({
  declarations: [
    AppComponent,
    AuthComponent,
    ErrorInterceptorComponent,
    HomeComponent,
    AboutComponent,
    NavMenuComponent,
    NotFoundComponent,
    AccountDashboardComponent,
    ItemsDashboardComponent,
    ItemViewerComponent,
    AccountViewerComponent,
    AccountFormComponent,
    AccountDetailComponent,
    ItemFormComponent,
    ItemDetailComponent,
    OrdersDashboardComponent,
    OrdersViewerComponent,
    OrderFormComponent,
    OrderDetailComponent,
    ReviewsDashboardComponent,
    ReviewViewerComponent,
    ReviewDetailComponent,
    ReviewFormComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
