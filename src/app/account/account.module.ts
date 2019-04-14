import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AccountDashboardComponent } from './containers/account-dashboard/account-dashboard.component';
import { AccountDetailComponent } from './components/account-detail/account-detail.component';
import { AccountFormComponent } from './components/account-form/account-form.component';
import { AccountViewerComponent } from './containers/account-viewer/account-viewer.component';

@NgModule({
  declarations: [
    AccountDashboardComponent,
    AccountDetailComponent,
    AccountFormComponent,
    AccountViewerComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    AccountDashboardComponent,
    AccountDetailComponent,
    AccountFormComponent,
    AccountViewerComponent
  ]
})
export class AccountModule { }
