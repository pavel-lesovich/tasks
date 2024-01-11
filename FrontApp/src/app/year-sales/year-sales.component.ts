import { Component } from '@angular/core';
import { YearSalesFilterFormComponent } from '../year-sales-filter-form/year-sales-filter-form.component';
import { YearSales as YearSales } from '../models/year-sales';
import { YearSalesListComponent } from '../year-sales-list/year-sales-list.component';
import { YearSalesFilter } from '../models/year-sales-filter';
import { YearSalesService } from '../services/year-sales.service';
import { YearSalesDetails } from '../models/year-sales-details';
import { YearSalesDetailsListComponent } from '../year-sales-details-list/year-sales-details-list.component';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-year-sales',
  standalone: true,
  imports: [
    CommonModule,
    YearSalesFilterFormComponent,
    YearSalesListComponent,
    YearSalesDetailsListComponent
  ],
  templateUrl: './year-sales.component.html',
  styleUrl: './year-sales.component.css'
})
export class YearSalesComponent {

  yearSalesList: YearSales[] = [];
  yearSalesDetailsList: YearSalesDetails[] | null = null;
  selectedYearSales: YearSales | null = null;

  constructor(private yearSalesService: YearSalesService) {
  }

  onGetData(filter: YearSalesFilter) {
    this.yearSalesService.getYearSalesList(filter)
      .subscribe(yearSalesList => {
        this.yearSalesList = yearSalesList ?? [];
        this.selectedYearSales = null;
        this.yearSalesDetailsList = null;
      });
  }

  async onSelectYearSales(yearSales: YearSales) {
    const { orderYear, timeToShipInDays } = yearSales;
    this.selectedYearSales = yearSales;
    this.yearSalesService
      .getYearSalesDetailsList({ orderYear, timeToShipInDays })
      .subscribe(yearSalesDetailsList => this.yearSalesDetailsList = yearSalesDetailsList);
  }
}
