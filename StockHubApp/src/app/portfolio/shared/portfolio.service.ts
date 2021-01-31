import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PortfolioService {
  private readonly baseUrl = 'https://localhost:44370/api/stock';

  public constructor(private httpClient: HttpClient) { }

  public getPortfolio(): Promise<object> {
    return this.httpClient.get(this.baseUrl).toPromise();
  }
}
