import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { PortfolioService } from '../shared/portfolio.service';
import { Stock } from '../../stock/shared/stock.model';
import { PieChartData } from '../shared/pieChartData.model';

@Component({
    selector: 'app-portfolio-dashboard',
    templateUrl: './portfolio-dashboard.component.html',
    styleUrls: ['./portfolio-dashboard.css']
})
export class PortfolioDashboardComponent implements OnInit {
    /** The data which will be shown in the chart. */
    public chartData: PieChartData[] = [];

    /**
     * Creates a new instance of PortfolioDashbaord.
     *
     * @param portfolioService The via dependency injection loaded service for portfolio actions.
     * @param toastrService The via dependency injection loaded service for showing toasts.
     */
    public constructor(private portfolioService: PortfolioService, private toastrService: ToastrService) { }

    /**
     * Gets the Stock[] data from the backend and setups the portfolio chart with its values.
     */
    ngOnInit(): void {
        this.portfolioService.getPortfolio()
            .then((result) => {
                this.chartData = this.createChartData(result as Stock[]);
            },
            error => {
                this.toastrService.error($localize`Loading portfolio failed.`);
                console.error(error);
            });
    }

    private createChartData(stocks: Stock[]): PieChartData[] {
        const chartData: PieChartData[] = [];

        for (const stock of stocks) {
            chartData.push(new PieChartData(stock.name.toString(), +stock.amount * +stock.acquisitionPricePerUnit));
        }

        return chartData;
    }
}
