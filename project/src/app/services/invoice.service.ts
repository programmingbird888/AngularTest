import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Invoice } from '../models/invoice.model';
import { Currency } from '../models/currency.model';

@Injectable({
  providedIn: 'root'
})
export class InvoiceService {
  private apiUrl = 'https://localhost:7082/api/invoice';

  constructor(private http: HttpClient) {}

  getInvoices(currencyId:number, vendorId:number): Observable<Invoice[]> {
    return this.http.get<Invoice[]>(`${this.apiUrl}/invoicelist/${currencyId}/${vendorId}`);
  }

  getInvoice(invoiceId: number): Observable<Invoice> {
    return this.http.get<Invoice>(`${this.apiUrl}/invoicebyid/${invoiceId}`);
  }

  addInvoice(invoice: Invoice): Observable<Invoice> {
    return this.http.post<Invoice>(`${this.apiUrl}`+ "/createinvoice", invoice);
  }

  updateInvoice(invoiceId: number, invoice: Invoice): Observable<Invoice> {
    return this.http.put<Invoice>(`${this.apiUrl}/updateinvoice/${invoiceId}`, invoice);
  }

  deleteInvoice(invoiceId: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/deleteinvoice/${invoiceId}`);
  }
}
