import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PortfolioDashboardComponent } from 'src/app/portfolio/portfolio-dashboard/portfolio-dashboard.component';
import { StockDetailsFormComponent } from '../../stock/stock-details/stock-details-form/stock-details-form.component';
import { StockDetailsComponent } from '../../stock/stock-details/stock-details.component';

const routes: Routes = [
  { path: '', component: PortfolioDashboardComponent },
  { path: 'portfolio', component: PortfolioDashboardComponent },
  { path: 'stocks', component: StockDetailsComponent },
  { path: 'stocks/new', component: StockDetailsFormComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
