import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';

@Injectable({
    providedIn: 'root'
})
export class PortfolioService {
    /**
     * Creates a new instance of the PortfolioService class.
     *
     * @param httpClient The via dependency injection loaded HttpClient.
     */
    public constructor(private httpClient: HttpClient) { }

    /**
     * Gets a Stock[] from the backend.
     *
     * @returns A Promise of unknown.
     */
    public getPortfolio(): Promise<unknown> {
        return this.httpClient.get(environment.apiUrlStock).toPromise();
    }
}
