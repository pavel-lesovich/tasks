import { Component, Input } from '@angular/core';
import { YearSalesDetails } from '../models/year-sales-details';
import { CommonModule } from '@angular/common';
import { WindowService } from '../services/window.service';

@Component({
  selector: 'app-year-sales-details-list',
  standalone: true,
  imports: [
    CommonModule
  ],
  templateUrl: './year-sales-details-list.component.html',
  styleUrl: './year-sales-details-list.component.css'
})
export class YearSalesDetailsListComponent {
  @Input() yearSalesDetailsList?: YearSalesDetails[];

  constructor(private windowService: WindowService) {
    
  }

  getQuery(yearSalesDetails: YearSalesDetails){
    return this.windowService.encodeURIComponent(yearSalesDetails.contactName);
  }

}
