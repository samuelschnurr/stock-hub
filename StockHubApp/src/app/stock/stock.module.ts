import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { StockDetailsComponent } from './stock-details/stock-details.component';
import { StockListComponent } from './stock-list/stock-list.component';

@NgModule({
  declarations: [StockDetailsComponent, StockListComponent],
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule
  ]
})
export class StockModule { }
