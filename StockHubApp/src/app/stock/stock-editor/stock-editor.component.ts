import { Component } from '@angular/core';
import { StockService } from '../shared/stock.service';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Stock } from '../shared/stock.model';

@Component({
  selector: 'app-stock-editor',
  templateUrl: './stock-editor.component.html'
})
export class StockEditorComponent {
  public stockForm: FormGroup;

  public constructor(public stockService: StockService, private router: Router, private formBuilder: FormBuilder) {
    this.stockForm = this.formBuilder.group(new Stock());
  }

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
