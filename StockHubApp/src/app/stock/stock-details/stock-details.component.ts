import { Component } from '@angular/core';
import { StockService } from '../shared/stock.service';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-stock-details',
  templateUrl: './stock-details.component.html'
})
export class StockDetailsComponent {
  public constructor(private router: Router, public stockService: StockService) { }

  public onSubmit(form: NgForm): void {
    this.stockService.postStock().subscribe(
      result => {
        console.log("success");
        this.router.navigate(['stocks']);
      },
      error => {
        console.error(error);
      }
    );
  }
}
