import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PortfolioService {
  public constructor(private httpClient: HttpClient) { }

  public getPortfolio(): Promise<object> {
    return this.httpClient.get(environment.apiUrlStock).toPromise();
  }
}
