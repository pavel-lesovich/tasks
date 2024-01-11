import { Component, EventEmitter, Input, Output } from '@angular/core';
import { YearSales } from '../models/year-sales';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-year-sales-list',
  standalone: true,
  imports: [
    CommonModule],
  templateUrl: './year-sales-list.component.html',
  styleUrl: './year-sales-list.component.css'
})
export class YearSalesListComponent {
  @Input() yearSalesList!: YearSales[];
  @Input() selectedYearSales: YearSales | null = null;

  @Output() selectYearSales = new EventEmitter<YearSales>();

  clickRow(yearSales: YearSales) {
    this.selectYearSales.emit(yearSales);
  }

  isSelected(yearSales: YearSales) {
    return this.selectedYearSales &&
      this.selectedYearSales.orderYear === yearSales.orderYear &&
      this.selectedYearSales.timeToShipInDays === yearSales.timeToShipInDays;
  }
}
