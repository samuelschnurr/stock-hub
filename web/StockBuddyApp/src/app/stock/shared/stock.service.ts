import { Injectable } from '@angular/core';
import { Stock } from './stock.model';

@Injectable({
  providedIn: 'root'
})
export class StockService {

  constructor() { }

  public formData: Stock = new Stock();
}
