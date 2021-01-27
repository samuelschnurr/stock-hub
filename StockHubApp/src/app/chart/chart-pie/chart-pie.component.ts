import { Component } from '@angular/core';

@Component({
  selector: 'app-chart-pie',
  templateUrl: './chart-pie.component.html'
})
export class ChartPieComponent {
  public constructor() { }

  // ToDo: Get values wie REST-Call and use service class
  public dataSet = [
    { name: 'Microsoft', value: 46 },
    { name: 'Amazon', value: 14 },
    { name: 'Bayer', value: 10 },
    { name: 'Netflix', value: 14 },
    { name: 'Danone', value: 16 }
  ];
}
