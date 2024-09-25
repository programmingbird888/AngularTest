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

  getCurrency(currencyId : number): Observable<Currency> {
    return this.http.get<Currency>(`${this.apiUrl}/currencybyid/${currencyId}`);
  }

  addCurrency(currency: Currency): Observable<Currency> {
    return this.http.post<Currency>(`${this.apiUrl}` + "/createcurrency", currency);
  }

  updateCurrency(currencyId : number, currency: Currency): Observable<Currency> {
    return this.http.put<Currency>(`${this.apiUrl}/updatecurrency/${currencyId}`, currency);
  }

  deleteCurrency(currencyId : number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/deletecurrency/${currencyId}`);
  }
}
