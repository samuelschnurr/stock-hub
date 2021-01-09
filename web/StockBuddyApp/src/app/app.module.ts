import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { StockModule } from './stock/stock.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    StockModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
