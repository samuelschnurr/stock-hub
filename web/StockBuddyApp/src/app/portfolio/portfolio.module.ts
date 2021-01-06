import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PortfolioListComponent } from './portfolio-list/portfolio-list.component';
import { PortfolioDetailsComponent } from './portfolio-details/portfolio-details.component';
import { PortfolioDashboardComponent } from './portfolio-dashboard/portfolio-dashboard.component';



@NgModule({
  declarations: [PortfolioListComponent, PortfolioDetailsComponent, PortfolioDashboardComponent],
  imports: [
    CommonModule
  ]
})
export class PortfolioModule { }
