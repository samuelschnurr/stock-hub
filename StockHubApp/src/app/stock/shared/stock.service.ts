import { Injectable } from '@angular/core';
import { Stock } from './stock.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class StockService {
  public formData: Stock = new Stock();
  private readonly baseUrl = '...';

  public constructor(private httpClient: HttpClient) { }

  public postStock() {
    return this.httpClient.post(this.baseUrl, this.formData);
  }
}
