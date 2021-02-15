import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Stock } from '../shared/stock.model';
import { StockService } from '../shared/stock.service';

@Component({
  selector: 'app-stock-list',
  templateUrl: './stock-list.component.html'
})
export class StockListComponent implements OnInit {
  public constructor(public stockService: StockService, private router: Router) { }

  ngOnInit(): void {
    this.stockService.refreshList();
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
   * Deletes a record by a given id and refreshes the list component.
   * @param id The id of the record which should be deleted.
   */
  public onDelete(id: number): void {
    this.stockService.deleteStock(id).subscribe(
      result => {
        console.log('success');
        this.stockService.refreshList();
      },
      error => {
        console.error(error);
      }
    );
  }
}
