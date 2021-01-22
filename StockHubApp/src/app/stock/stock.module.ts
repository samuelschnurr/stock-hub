import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { StockDetailsComponent } from './stock-details/stock-details.component';
import { StockDetailsFormComponent } from './stock-details/stock-details-form/stock-details-form.component';

@NgModule({
  declarations: [StockDetailsComponent, StockDetailsFormComponent],
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule
  ],
  exports: [
    StockDetailsComponent
  ]
})

export class StockModule { }
