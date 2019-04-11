import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthComponent } from './auth/auth.component';
import { ErrorInterceptorComponent } from './helpers/error-interceptor/error-interceptor.component';
import { HomeComponent } from './home/home.component';
import { ItemsComponent } from './items/items.component';
import { ReviewsComponent } from './reviews/reviews.component';
import { OrdersComponent } from './orders/orders.component';
import { AccountComponent } from './account/account.component';
import { AboutComponent } from './about/about.component';

@NgModule({
  declarations: [
    AppComponent,
    AuthComponent,
    ErrorInterceptorComponent,
    HomeComponent,
    ItemsComponent,
    ReviewsComponent,
    OrdersComponent,
    AccountComponent,
    AboutComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
