import { Injectable } from '@angular/core';
import { YearSales } from '../models/year-sales';
import { YearSalesFilter } from '../models/year-sales-filter';
import { YearSalesDetailsFilter } from '../models/year-sales-details-filter';
import { YearSalesDetails } from '../models/year-sales-details';
import { environment } from '../../environments/environment.development';
import { HttpClient, HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class YearSalesService {

  constructor(private http: HttpClient) { }

  getYearSalesList(filter: YearSalesFilter) {

    const { maxTotal, minTimeToShipInDays } = filter;

    const fetchUrl = `${environment.apiBaseUrl}/YearSales`;

    let params = new HttpParams({ fromObject: { minTimeToShipInDays } });
    maxTotal && (params = params.set('maxTotal', maxTotal));

    return this.http.get<YearSales[]>(fetchUrl, { params });
  }

  getYearSalesDetailsList(filter: YearSalesDetailsFilter) {
    const { orderYear, timeToShipInDays } = filter;
    const params = new HttpParams({ fromObject: { orderYear, timeToShipInDays } });

    const fetchUrl = `${environment.apiBaseUrl}/YearSalesDetails`;

    return this.http.get<YearSalesDetails[]>(fetchUrl, { params });
  }
}
