import { Component, OnInit } from '@angular/core';
import { StockService } from '../../shared/stock.service';

@Component({
  selector: 'app-stock-details-form',
  templateUrl: './stock-details-form.component.html',
  styleUrls: ['./stock-details-form.component.css']
})
export class StockDetailsFormComponent implements OnInit {
  constructor(public stockService: StockService) { }

  ngOnInit(): void {
  }

}
