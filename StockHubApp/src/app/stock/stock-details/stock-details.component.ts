import { Component } from '@angular/core';
import { StockService } from '../shared/stock.service';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-stock-details',
  templateUrl: './stock-details.component.html'
})
export class StockDetailsComponent {
  public constructor(public stockService: StockService, private router: Router) { }

  public onSubmit(form: NgForm): void {
    if (this.stockService.formData.id === 0) {
      this.insertRecord(form);
    } else {
      this.updateRecord(form);
    }
  }

  private insertRecord(form: NgForm): void {
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

  private updateRecord(form: NgForm): void {
    this.stockService.updateStock().subscribe(
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
