import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Invoice } from '../Models/invoice';

@Injectable({
  providedIn: 'root'
})
export class InvoiceService {
  private apiUrl = 'https://localhost:7082/api/invoice';

  constructor(private http: HttpClient) {}

  getInvoices(): Observable<Invoice[]> {
    return this.http.get<Invoice[]>(`${this.apiUrl}`+ "/invoicelist");
  }

  getInvoice(invoiceNumber: string): Observable<Invoice> {
    return this.http.get<Invoice>(`${this.apiUrl}/${invoiceNumber}` + "invoicebynumber");
  }

  addInvoice(invoice: Invoice): Observable<Invoice> {
    return this.http.post<Invoice>(`${this.apiUrl}`+ "/createinvoice", invoice);
  }

  updateInvoice(invoiceNumber: string, invoice: Invoice): Observable<Invoice> {
    return this.http.put<Invoice>(`${this.apiUrl}/${invoiceNumber}` + "updateinvoice", invoice);
  }

  deleteInvoice(invoiceNumber: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${invoiceNumber}` + "deleteinvoice");
  }
}
