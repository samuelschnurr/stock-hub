// Showcase without global errohandling and logging
// So diable no-console in this file
/* eslint-disable no-console */
import { Injectable } from '@angular/core';
import { Stock } from './stock.model';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { ToastrService } from 'ngx-toastr';

@Injectable({
    providedIn: 'root'
})
export class StockService {
    /** The formData of a Stock. Used for creating and updating Stock data.  */
    public formData: Stock = new Stock();
    /** A list which contains all stocks in the database. */
    public list: Stock[] = [];

    /**
     * Creates a new instance of the StockService class.
     *
     * @param httpClient The via dependency injection loaded HttpClient.
     * @param toastrService The via dependency injection loaded service for showing toasts.
     */
    public constructor(private httpClient: HttpClient, private toastrService: ToastrService) { }

    /**
     * Posts the formData to the backend.
     *
     * @returns A observable unknown of the post response.
     */
    public postStock(): Observable<unknown> {
        return this.httpClient.post(environment.apiUrlStock, this.formData);
    }

    /**
     * Puts the formData to the backend.
     *
     * @returns A observable unknown of the put response.
     */
    public updateStock(): Observable<unknown> {
        console.info(`Updating stock with id: ${this.formData.id}`);
        return this.httpClient.put(`${environment.apiUrlStock}/${this.formData.id}`, this.formData);
    }

    /**
     * Deletes the formData to the backend.
     *
     * @param id The id of the Stock to delete.
     * @returns A observable unknown of the delete response.
     */
    public deleteStock(id: number): Observable<unknown> {
        console.info(`Deleting stock with id: ${id}`);
        return this.httpClient.delete(`${environment.apiUrlStock}/${id}`);
    }

    /**
     * Gets a Stock[] from the backend and refreshes the list with its values.
     * Resets the latest formData.
     *
     * @returns A Promise of Stock[] if successful, else void.
     */
    public refreshList(): Promise<void | Stock[]> {
        return this.httpClient.get(environment.apiUrlStock)
            .toPromise()
            .then((result) => {
                this.list = result as Stock[];
                this.formData = new Stock();
            },
            error => {
                this.toastrService.error($localize`Loading stocks failed.`);
                console.log(error);
            });
    }
}
