import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StockDetailsComponent } from './stock-details/stock-details.component';

@NgModule({
  declarations: [StockDetailsComponent],
  imports: [
    CommonModule
  ],
  exports: [
    StockDetailsComponent
  ]
})

export class StockModule { }
