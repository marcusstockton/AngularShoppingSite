import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ErrorInterceptorComponent } from './helpers/error-interceptor/error-interceptor.component';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HttpClientModule } from '@angular/common/http';
import { NotFoundComponent } from './not-found.component';
import { AuthModule } from './auth/auth.module';
import { ItemsModule } from './items/items.module';
import { OrdersModule } from './orders/orders.module';
import { AccountModule } from './account/account.module';
import { ReviewsModule } from './reviews/reviews.module';
import { CoreModule } from './core/core.module';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { LayoutModule } from '@angular/cdk/layout';
import { MatToolbarModule, MatButtonModule, MatSidenavModule, MatIconModule, MatListModule } from '@angular/material';

@NgModule({
  declarations: [
    AppComponent,
    ErrorInterceptorComponent,
    HomeComponent,
    AboutComponent,
    NavMenuComponent,
    NotFoundComponent,
    NavBarComponent,
  
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    AuthModule,
    ItemsModule,
    OrdersModule,
    AccountModule,
    ReviewsModule,
    CoreModule,
    LayoutModule,
    MatToolbarModule,
    MatButtonModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
