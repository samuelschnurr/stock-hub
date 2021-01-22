import { Injectable } from '@angular/core';
import { Stock } from './stock.model';
import { HttpClient } from '@angular/common/http';

/**
 * Class Definition of Stock.
 */
@Injectable({
  providedIn: 'root'
})
export class StockService {
  public formData: Stock = new Stock();
  private readonly baseUrl = '...';

 /**
  * Initializes a new instance of the StockService class.
  * @param httpClient The via dependency injection loaded HttpClient.
  */
  public constructor(private httpClient: HttpClient) { }

  /**
   * Posts the formData to the backend.
   */
  public postStock() {
    return this.httpClient.post(this.baseUrl, this.formData);
  }
}
