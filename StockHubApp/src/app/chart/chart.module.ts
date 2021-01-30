import { NgModule } from '@angular/core';
import { NgxChartsModule } from '@swimlane/ngx-charts';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ChartPieComponent } from './chart-pie/chart-pie.component';

@NgModule({
  declarations: [ChartPieComponent],
  imports: [
    BrowserAnimationsModule,
    NgxChartsModule
  ],
  exports: [
    ChartPieComponent
  ]
})
export class ChartModule { }
