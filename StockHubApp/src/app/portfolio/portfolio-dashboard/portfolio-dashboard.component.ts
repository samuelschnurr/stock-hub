import { Component, OnInit } from '@angular/core';
import { PortfolioService } from '../shared/portfolio.service';
import { Stock } from '../../stock/shared/stock.model';
import { ToastrService } from 'ngx-toastr';

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
                console.log('success');
                this.chartData = this.createChartData(result as Stock[]);
            },
            error => {
                this.toastrService.error($localize`Loading portfolio failed.`);
                console.log(error);
            });
    }

    private createChartData(stocks: Stock[]): any[] {
        const chartData: any[] = [];

        for (const stock of stocks) {
            chartData.push({ name: stock.name, value: +stock.amount * +stock.acquisitionPricePerUnit });
        }

        return chartData;
    }
}
