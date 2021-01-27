import { Injectable } from '@angular/core';
import { Stock } from './stock.model';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StockService {
  public formData: Stock = new Stock();
  public list: Stock[] = [];
  private readonly baseUrl = 'https://localhost:44370/api/stock';

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

  public updateStock(): Observable<object> {
    return this.httpClient.put(`${this.baseUrl}/${this.formData.id}`, this.formData);
  }

  public deleteStock(id: number): Observable<object> {
    return this.httpClient.delete(`${this.baseUrl}/${id}`);
  }

  public refreshList(): Promise<void | Stock[]> {
    return this.httpClient.get(this.baseUrl)
      .toPromise()
      .then(result => this.list = result as Stock[],
        error => console.log(error));
  }
}
