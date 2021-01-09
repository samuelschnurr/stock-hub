import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StockDetailsComponent } from './stock-details/stock-details.component';
import { StockDetailsFormComponent } from './stock-details/stock-details-form/stock-details-form.component';

@NgModule({
  declarations: [StockDetailsComponent, StockDetailsFormComponent],
  imports: [
    CommonModule
  ],
  exports: [
    StockDetailsComponent
  ]
})

export class StockModule { }
