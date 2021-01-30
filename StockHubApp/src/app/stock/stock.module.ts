import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { StockDetailsComponent } from './stock-details/stock-details.component';
import { StockListComponent } from './stock-list/stock-list.component';
import { CoreModule } from '../core/core.module';

@NgModule({
  declarations: [StockDetailsComponent, StockListComponent],
  imports: [
    CommonModule,
    HttpClientModule,
    CoreModule,
    ReactiveFormsModule
  ]
})
export class StockModule { }
