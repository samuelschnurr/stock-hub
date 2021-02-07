import { Component, OnInit } from '@angular/core';
import { StockService } from '../shared/stock.service';
import { AbstractControl, FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Stock } from '../shared/stock.model';

@Component({
  selector: 'app-stock-editor',
  templateUrl: './stock-editor.component.html'
})
export class StockEditorComponent implements OnInit {
  public stockForm: FormGroup;

  public constructor(public stockService: StockService, private router: Router, private formBuilder: FormBuilder) {
    this.stockForm = this.formBuilder.group(new Stock());
  }

  public ngOnInit(): void {
    if (this.stockService.formData.id !== 0) {
      this.stockForm.patchValue(this.stockService.formData);
    }
  }

  public onSubmit(): void {
    if (!this.stockForm.valid) {
      return;
    }

    this.stockService.formData = this.stockForm.value;

    if (this.stockService.formData.id === 0) {
      this.insertRecord();
    } else {
      this.updateRecord();
    }
  }

  public get name(): AbstractControl | null {
    return this.stockForm.get('name');
  }

  public get amount(): AbstractControl | null {
    return this.stockForm.get('amount');
  }

  public get acquisitionPricePerUnit(): AbstractControl | null {
    return this.stockForm.get('acquisitionPricePerUnit');
  }

  private resetForm(): void {
    this.stockForm.reset();
    this.stockService.formData = new Stock();
  }

  private insertRecord(): void {
    this.stockService.postStock().subscribe(
      result => {
        console.log('success');
        this.resetForm();
        this.router.navigate(['stocks']);
      },
      error => {
        console.error(error);
      }
    );
  }

  private updateRecord(): void {
    this.stockService.updateStock().subscribe(
      result => {
        console.log('success');
        this.resetForm();
        this.router.navigate(['stocks']);
      },
      error => {
        console.error(error);
      }
    );
  }
}
