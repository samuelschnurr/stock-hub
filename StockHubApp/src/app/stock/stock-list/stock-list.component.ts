import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Stock } from '../shared/stock.model';
import { StockService } from '../shared/stock.service';

@Component({
  selector: 'app-stock-list',
  templateUrl: './stock-list.component.html'
})
export class StockListComponent implements OnInit {
  /** The id of the record which opened the modal dialog. */
  public modalId = 0;
  /** The body of the modal dialog. */
  public modalBody = $localize`Do you want to delete this stock?`;
  /** Can be bound to hide table elements to prevent seeing the table resize after data load. */
  public isRefreshListFinished = false;

  /**
   * Creates a new instance of the StockList class.
   * @param stockService The via dependency injection loaded service for stock actions.
   * @param toastrService The via dependency injection loaded service for showing toasts.
   * @param router The via dependency injection loaded router for navigation actions.
   */
  public constructor(public stockService: StockService, private toastrService: ToastrService, private router: Router) { }

  ngOnInit(): void {
    this.stockService.refreshList().then(() =>
      this.isRefreshListFinished = true
    );
  }

  /**
   * Populates a form to edit values of the currently selected record.
   * @param selectedRecord The record of a Stock which values should be instantiated.
   */
  public populateForm(selectedRecord: Stock): void {
    // Use Object.assign to not copy the reference to the list
    this.stockService.formData = Object.assign({}, selectedRecord);
    this.router.navigate(['stocks/new']);
  }

  /**
   * Is fired when user clicked on the delete icon of a stock.
   * Stores the selected id in a local variable for further processing.
   * @param id The number of the record which is selected for deletion.
   */
  public onDelete(id: number): void {
    this.modalId = id;
  }

  /**
   * Deletes a record by a given id and refreshes the list component after the moda dialog is submitted.
   * @param id The id which is emitted by the modal dialog at submit.
   */
  public submitModal(id: number): void {
    this.stockService.deleteStock(id).subscribe(
      () => {
        this.toastrService.success($localize`Stock is deleted.`);
        this.stockService.refreshList();
      },
      error => {
        this.toastrService.error($localize`Deleting stock failed.`);
        console.error(error);
      }
    );
  }
}
