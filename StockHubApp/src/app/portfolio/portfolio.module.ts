import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PortfolioDashboardComponent } from './portfolio-dashboard/portfolio-dashboard.component';
import { CoreModule } from '../core/core.module';
import { ChartModule } from '../chart/chart.module';

@NgModule({
  declarations: [PortfolioDashboardComponent],
  imports: [
    CommonModule,
    CoreModule,
    ChartModule
  ]
})
export class PortfolioModule { }
