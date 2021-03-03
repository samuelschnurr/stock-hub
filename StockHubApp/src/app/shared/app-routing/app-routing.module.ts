import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PortfolioDashboardComponent } from '../../portfolio/portfolio-dashboard/portfolio-dashboard.component';
import { StockEditorComponent } from '../../stock/stock-editor/stock-editor.component';
import { StockListComponent } from '../../stock/stock-list/stock-list.component';

const routes: Routes = [
    { path: '', redirectTo: 'portfolio', pathMatch: 'full' },
    { path: 'portfolio', component: PortfolioDashboardComponent },
    { path: 'stocks', component: StockListComponent },
    { path: 'stocks/new', component: StockEditorComponent },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
