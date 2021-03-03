import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgxChartsModule } from '@swimlane/ngx-charts';
import { SharedModule } from '../shared/shared.module';
import { PortfolioDashboardComponent } from './portfolio-dashboard/portfolio-dashboard.component';

@NgModule({
    declarations: [PortfolioDashboardComponent],
    imports: [
        BrowserAnimationsModule,
        NgxChartsModule,
        SharedModule
    ]
})
export class PortfolioModule { }
