import { Component, EventEmitter, Output } from '@angular/core';
import { YearSalesFilter } from '../models/year-sales-filter';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-year-sales-filter-form',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './year-sales-filter-form.component.html',
  styleUrl: './year-sales-filter-form.component.css'
})
export class YearSalesFilterFormComponent {
  model: YearSalesFilter = { minTimeToShipInDays: 7 };

  @Output() getData = new EventEmitter<YearSalesFilter>();

  onSubmit() {
    this.getData.emit(this.model);
  }
}
