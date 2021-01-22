import { Component } from '@angular/core';
import { StockService } from '../../shared/stock.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-stock-details-form',
  templateUrl: './stock-details-form.component.html'
})
export class StockDetailsFormComponent {
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
