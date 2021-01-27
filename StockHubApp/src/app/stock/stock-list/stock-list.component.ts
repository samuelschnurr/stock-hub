import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Stock } from '../shared/stock.model';
import { StockService } from '../shared/stock.service';

@Component({
  selector: 'app-stock-list',
  templateUrl: './stock-list.component.html'
})
export class StockListComponent implements OnInit {
  public constructor(public stockService: StockService, private router: Router) { }

  ngOnInit(): void {
    this.stockService.refreshList();
  }

  public populateForm(selectedRecord: Stock): void {
    this.router.navigate(['/stocks/new']);

    // Use Object.assign to not copy the reference to the list
    this.stockService.formData = Object.assign({}, selectedRecord);
  }
}
