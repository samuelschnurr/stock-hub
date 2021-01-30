import { Component } from '@angular/core';
import { StockService } from '../shared/stock.service';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-stock-details',
  templateUrl: './stock-details.component.html'
})
export class StockDetailsComponent {
  stockForm = this.formBuilder.group({
    name: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(50)]],
    amount: ['', [Validators.required]],
    acquisitionPricePerUnit: ['', [Validators.required]]
  });


  public constructor(public stockService: StockService, private router: Router, private formBuilder: FormBuilder) { }

  public onSubmit(): void {
    if (this.stockService.formData.id === 0) {
      //this.insertRecord(form);
    } else {
      //this.updateRecord(form);
    }
  }

  // private resetForm(form: NgForm): void {
  //   form.form.reset();
  //   this.stockService.formData = new Stock();
  // }

  // private insertRecord(form: NgForm): void {
  //   this.stockService.postStock().subscribe(
  //     result => {
  //       console.log('success');
  //       this.resetForm(form);
  //       this.router.navigate(['stocks']);
  //     },
  //     error => {
  //       console.error(error);
  //     }
  //   );
  // }

  // private updateRecord(form: NgForm): void {
  //   this.stockService.updateStock().subscribe(
  //     result => {
  //       console.log('success');
  //       this.resetForm(form);
  //       this.router.navigate(['stocks']);
  //     },
  //     error => {
  //       console.error(error);
  //     }
  //   );
  // }
}
