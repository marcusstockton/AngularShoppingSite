import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { AuthComponent } from './auth/auth.component';
import { NotFoundComponent } from './not-found.component';
import { AccountDashboardComponent } from './account/containers/account-dashboard/account-dashboard.component';
import { ItemsDashboardComponent } from './items/containers/items-dashboard/items-dashboard.component';
import { OrdersDashboardComponent } from './orders/containers/orders-dashboard/orders-dashboard.component';
import { ReviewsDashboardComponent } from './reviews/containers/reviews-dashboard/reviews-dashboard.component';
import { ItemDetailComponent } from './items/components/item-detail/item-detail.component';
import { ItemCreateComponent } from './items/components/item-create/item-create.component';
import { ItemEditComponent } from './items/components/item-edit/item-edit.component';
import { AuthGuard } from './guards/auth.guard';

const routes: Routes = [
  { path: '', component: HomeComponent },
  {
    path: 'items',
    children: [
      { path: '', component: ItemsDashboardComponent },
      { path: 'create', component: ItemCreateComponent, canActivate: [AuthGuard]},
      { path: ':id', component: ItemDetailComponent },
      { path: ':id/edit', component: ItemEditComponent, canActivate: [AuthGuard] }
    ],
  },
  { path: 'reviews',
      children: [
      { path: '', component: ReviewsDashboardComponent },
      // { path: 'create', component: ItemCreateComponent, canActivate: [AuthGuard]},
      // { path: ':id', component: ItemDetailComponent },
      // { path: ':id/edit', component: ItemEditComponent, canActivate: [AuthGuard] }
  ], },
  { path: 'account', component: AccountDashboardComponent },
  { path: 'orders', component: OrdersDashboardComponent },
  { path: 'about', component: AboutComponent },
  { path: 'auth', component: AuthComponent },
  { path: '**', component: NotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
