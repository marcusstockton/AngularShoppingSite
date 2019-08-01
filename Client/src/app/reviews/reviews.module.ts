import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReviewDetailComponent } from './components/review-detail/review-detail.component';
import { ReviewFormComponent } from './components/review-form/review-form.component';
import { ReviewViewerComponent } from './containers/review-viewer/review-viewer.component';
import { ReviewsDashboardComponent } from './containers/reviews-dashboard/reviews-dashboard.component';
import { CoreModule } from '../core/core.module';

@NgModule({
  declarations: [
    ReviewDetailComponent,
    ReviewFormComponent,
    ReviewViewerComponent,
    ReviewsDashboardComponent
  ],
  imports: [
    CommonModule,
    CoreModule
  ],
  exports: [
    ReviewDetailComponent,
    ReviewFormComponent,
    ReviewViewerComponent,
    ReviewsDashboardComponent
  ]
})
export class ReviewsModule { }
