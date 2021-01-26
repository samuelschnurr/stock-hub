import { Component, OnInit } from '@angular/core';
import { StockService } from '../shared/stock.service';

@Component({
  selector: 'app-stock-details',
  templateUrl: './stock-details.component.html'
})
export class StockDetailsComponent implements OnInit {
  public constructor(public stockService: StockService) { }

  ngOnInit(): void {
    this.stockService.refreshList();
  }
}
