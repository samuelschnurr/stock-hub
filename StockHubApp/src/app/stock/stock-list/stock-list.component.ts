import { Component, OnInit } from '@angular/core';
import { StockService } from '../shared/stock.service';

@Component({
  selector: 'app-stock-list',
  templateUrl: './stock-list.component.html'
})
export class StockListComponent implements OnInit {
  public constructor(public stockService: StockService) { }

  ngOnInit(): void {
    this.stockService.refreshList();
  }
}
