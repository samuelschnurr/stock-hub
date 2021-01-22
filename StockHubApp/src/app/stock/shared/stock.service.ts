import { Injectable } from '@angular/core';
import { Stock } from './stock.model';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

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
   * @returns A observable object of the post response.
   */
  public postStock(): Observable<object> {
    return this.httpClient.post(this.baseUrl, this.formData);
  }
}
