import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { BrowserModule } from '@angular/platform-browser';
import { CoreModule } from './core/core.module';
import { SharedModule } from './shared/shared.module';
import { PortfolioModule } from './portfolio/portfolio.module';
import { StockModule } from './stock/stock.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    CoreModule,
    SharedModule,
    PortfolioModule,
    StockModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
