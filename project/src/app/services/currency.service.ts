import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Currency } from '../models/currency.model';

@Injectable({
  providedIn: 'root'
})
export class CurrencyService {
  private apiUrl = 'https://localhost:7082/api/currency';

  constructor(private http: HttpClient) {}

  getCurrencies(): Observable<Currency[]> {
    return this.http.get<Currency[]>(`${this.apiUrl}` + "/currencylist");
  }

  getCurrency(currencyCode: string): Observable<Currency> {
    return this.http.get<Currency>(`${this.apiUrl}/${currencyCode}` + "currencybycode");
  }

  addCurrency(currency: Currency): Observable<Currency> {
    return this.http.post<Currency>(`${this.apiUrl}` + "/createcurrency", currency);
  }

  updateCurrency(currencyCode: string, currency: Currency): Observable<Currency> {
    return this.http.put<Currency>(`${this.apiUrl}/${currencyCode}` + "updatecurrency", currency);
  }

  deleteCurrency(currencyCode: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${currencyCode}` + "deletecurrency");
  }
}
