import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { StockEditorComponent } from './stock-editor/stock-editor.component';
import { StockListComponent } from './stock-list/stock-list.component';

@NgModule({
  declarations: [StockEditorComponent, StockListComponent],
  imports: [
    SharedModule
  ]
})
export class StockModule { }
