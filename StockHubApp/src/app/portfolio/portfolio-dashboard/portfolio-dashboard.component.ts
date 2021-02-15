import { Component, OnInit } from '@angular/core';
import { PortfolioService } from '../shared/portfolio.service';
import { Stock } from '../../stock/shared/stock.model';

@Component({
  selector: 'app-portfolio-dashboard',
  templateUrl: './portfolio-dashboard.component.html',
  styleUrls: ['./portfolio-dashboard.css']
})
export class PortfolioDashboardComponent implements OnInit {
  /** The data which will be shown in the chart. */
  public chartData: any[] = [];

  /**
   * Creates a new instance of PortfolioDashbaord.
   * @param portfolioService The via dependency injection loaded service for portfolio actions.
   */
  public constructor(private portfolioService: PortfolioService) { }

  /**
   * Gets the Stock[] data from the backend and setups the portfolio chart with its values.
   */
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
