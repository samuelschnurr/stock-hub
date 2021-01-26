import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { StockDetailsFormComponent } from './stock/stock-details/stock-details-form/stock-details-form.component';
import { StockDetailsComponent } from './stock/stock-details/stock-details.component';

const routes: Routes = [
  { path: 'first', component: StockDetailsComponent },
  { path: 'second', component: StockDetailsFormComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
