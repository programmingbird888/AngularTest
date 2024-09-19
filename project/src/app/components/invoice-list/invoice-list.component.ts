import { Component, OnInit } from '@angular/core';
import { InvoiceService } from '../../services/invoice.service';
import { Invoice } from '../../models/invoice.model';
import * as XLSX from 'xlsx';
import { Router } from '@angular/router';

@Component({
  selector: 'app-invoice-list',
  templateUrl: './invoice-list.component.html',
})
export class InvoiceListComponent implements OnInit {
  invoices: Invoice[] = [];

  constructor(private invoiceService: InvoiceService, private routes:Router) {}

  ngOnInit(): void {
    this.loadInvoices();
  }

  loadInvoices(): void {
    this.invoiceService.getInvoices().subscribe(invoices => {
      this.invoices = invoices;
    });
  }

  deleteInvoice(invoiceNumber: string): void {
    this.invoiceService.deleteInvoice(invoiceNumber).subscribe(() => {
      this.loadInvoices();
    });
  }

  UpdateInvoice(invoiceNumber:string){
    this.routes.navigate([`invoices/edit/${invoiceNumber}`]);
  }

  exportToExcel(): void {
    const ws = XLSX.utils.json_to_sheet(this.invoices);
    const wb = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb, ws, 'Invoices');
    XLSX.writeFile(wb, 'invoices.xlsx');
  }


}
