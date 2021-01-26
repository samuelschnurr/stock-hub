import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PortfolioDashboardComponent } from './portfolio-dashboard/portfolio-dashboard.component';
import { CoreModule } from '../core/core.module';

@NgModule({
  declarations: [PortfolioDashboardComponent],
  imports: [
    CommonModule,
    CoreModule
  ]
})
export class PortfolioModule { }
