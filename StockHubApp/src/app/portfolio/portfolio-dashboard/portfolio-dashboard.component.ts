import { Component, OnInit } from '@angular/core';
import { PortfolioService } from '../shared/portfolio.service';
import { Stock } from '../../stock/shared/stock.model';

@Component({
  selector: 'app-portfolio-dashboard',
  templateUrl: './portfolio-dashboard.component.html',
  styleUrls: ['./portfolio-dashboard.css']
})
export class PortfolioDashboardComponent implements OnInit {
  public title = 'StockHub';
  public chartData: any[] = [];

  public constructor(private portfolioService: PortfolioService) { }

  ngOnInit(): void {
    this.portfolioService.getPortfolio()
      .then((result) => {
        console.log('success');
        this.chartData = this.createChartData(result as Stock[]);
      },
        error => console.log(error));
  }

  private createChartData(stocks: Stock[]): any[] {
    const chartData: any[] = [];

    for (const stock of stocks) {
      chartData.push({ name: stock.name, value: +stock.amount * +stock.acquisitionPricePerUnit });
    }

    return chartData;
  }
}
