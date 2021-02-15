import { Injectable } from '@angular/core';
import { Stock } from './stock.model';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class StockService {
  public formData: Stock = new Stock();
  public list: Stock[] = [];

  /**
   * Creates a new instance of the StockService class.
   * @param httpClient The via dependency injection loaded HttpClient.
   */
  public constructor(private httpClient: HttpClient) { }

  /**
   * Posts the formData to the backend.
   * @returns A observable object of the post response.
   */
  public postStock(): Observable<object> {
    return this.httpClient.post(environment.apiUrlStock, this.formData);
  }

  /**
   * Puts the formData to the backend.
   * @returns A observable object of the put response.
   */
  public updateStock(): Observable<object> {
    return this.httpClient.put(`${environment.apiUrlStock}/${this.formData.id}`, this.formData);
  }

  /**
   * Deletes the formData to the backend.
   * @param id The id of the Stock to delete.
   * @returns A observable object of the delete response.
   */
  public deleteStock(id: number): Observable<object> {
    return this.httpClient.delete(`${environment.apiUrlStock}/${id}`);
  }

  /**
   * Gets a Stock[] from the backend and refreshes the list with its values.
   * Resets the latest formData.
   * @returns A Promise of Stock[] if successful, else void.
   */
  public refreshList(): Promise<void | Stock[]> {
    return this.httpClient.get(environment.apiUrlStock)
      .toPromise()
      .then((result) => {
        this.list = result as Stock[];
        this.formData = new Stock();
      },
        error => console.log(error));
  }
}
