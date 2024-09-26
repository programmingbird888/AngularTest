import { Component, OnInit } from '@angular/core';
import { InvoiceService } from '../../services/invoice.service';
import { Invoice } from '../../models/invoice.model';
import * as XLSX from 'xlsx';
import { Router } from '@angular/router';
import { Vendor } from 'src/app/models/vendor.model';
import { Currency } from '../../models/currency.model';
import { VendorService } from 'src/app/services/vendor.service';
import { CurrencyService } from 'src/app/services/currency.service';

@Component({
  selector: 'app-invoice-list',
  templateUrl: './invoice-list.component.html',
})
export class InvoiceListComponent implements OnInit {
  invoices: Invoice[] = [];
  vendor: Vendor[] = [];
  currency: Currency[] = [];
  currencyId: number = 0;
  vendorId:number = 0
  currentPage: number = 1;
  pageSize: number = 5;

  constructor(private invoiceService: InvoiceService, private routes:Router, private vendorService: VendorService, private currencyService: CurrencyService) {}

  ngOnInit(): void {
    this.loadInvoices();

    this.vendorService.getVendors(this.currentPage, this.pageSize).subscribe(data => {
      this.vendor = data;
    }, err => {
      alert(err.error);
    });

    this.currencyService.getCurrencies().subscribe(data => {
      this.currency = data;
    }, err => {
      alert(err);
    });
  }

  loadInvoices(): void {
    this.invoiceService.getInvoices(this.currencyId, this.vendorId).subscribe((get: Invoice[]) => {
      this.invoices = get;
    });
  }

  deleteInvoice(invoiceId: number): void {
    const confirmDelete = confirm("Are you sure you want to delete!");
    if (confirmDelete) {
      this.invoiceService.deleteInvoice(invoiceId).subscribe(() => {
        alert("Invoice Deleted.")
        this.loadInvoices();
      });
    }
  }

  UpdateInvoice(invoiceId: number){
    this.routes.navigate([`invoice/invoices/edit/${invoiceId}`]);
  }

  exportToExcel(): void {
    const ws = XLSX.utils.json_to_sheet(this.invoices);
    const wb = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb, ws, 'Invoices');
    XLSX.writeFile(wb, 'invoices.xlsx');
  }

  getCurrencyCode(currencyId: number): string {
    var curr = this.currency.find(c => c.currencyId == currencyId);
    if (curr != undefined)
    {
      return curr.currencyCode;
    }
    return "undefined";
  }

  getVendorName(vendorId: number): string {
    var name = this.vendor.find(v => v.vendorId == vendorId);
    if (name != undefined)
    {
      return name.vendorLongName;
    }
    return "undefined";
  }

  OnFilter() {
    this.invoiceService.getInvoices(this.vendorId, this.currencyId).subscribe((resp: Invoice[]) => {
      // console.log();
      this.invoices = resp;
    }, error => {
      alert(error.error);
      console.log(error);
    });
  }

}
