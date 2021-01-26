import { Component } from '@angular/core';
import { StockService } from '../shared/stock.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-stock-details',
  templateUrl: './stock-details.component.html'
})
export class StockDetailsComponent {
  public constructor(public stockService: StockService) { }

  public onSubmit(form: NgForm): void {
    this.stockService.postStock().subscribe(
      result => {
        console.log("success");
      },
      error => {
        console.error(error);
      }
    );
  }
}
