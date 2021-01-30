import { NgModule } from '@angular/core';
import { ChartModule } from '../chart/chart.module';
import { PortfolioDashboardComponent } from './portfolio-dashboard/portfolio-dashboard.component';

@NgModule({
  declarations: [PortfolioDashboardComponent],
  imports: [
    ChartModule
  ]
})
export class PortfolioModule { }
