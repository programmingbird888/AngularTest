import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { InvoiceService } from '../../services/invoice.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Invoice } from '../../models/invoice.model';
import { VendorService } from '../../services/vendor.service';
import { Currency } from '../../models/currency.model';
import { CurrencyService } from 'src/app/services/currency.service';
import { Vendor } from 'src/app/models/vendor.model';

@Component({
  selector: 'app-invoice-detail',
  templateUrl: './invoice-detail.component.html',
})
export class InvoiceDetailComponent implements OnInit {
  invoiceForm: FormGroup;
  isEdit: boolean = false;
  invoiceId: number = 0;
  vendorlist: Vendor[] = [];
  currencylist: Currency[] = [];
  currentPage: number = 1;
  pageSize: number = 5;

  constructor(
    private fb: FormBuilder,
    private invoiceService: InvoiceService,
    private router: Router,
    private route: ActivatedRoute,
    private vendorService: VendorService,
    private currencyService: CurrencyService
  ) {
    this.invoiceForm = this.fb.group({
      invoiceNumber: ['', Validators.required],
      invoiceAmount: ['', [Validators.required, Validators.min(0)]],
      invoiceCurrencyId: ['', Validators.required],
      invoiceDueDate: ['', Validators.required],
      vendorId: ['', Validators.required],
      isActive: [true]
    });
  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.invoiceId = params['invoiceId'];
      if (this.invoiceId) {
        this.loadInvoice(this.invoiceId);
        this.isEdit = true;
      }
    });
    this.vendorService.getVendors(this.currentPage, this.pageSize).subscribe(v=>this.vendorlist = v);
    this.currencyService.getCurrencies().subscribe(v=>this.currencylist = v);
  }

  loadInvoice(invoiceId: number): void {
    this.invoiceService.getInvoice(invoiceId).subscribe(invoice => {
      this.invoiceForm.patchValue(invoice);
    });
  }

  onSubmit(): void {
    if (this.invoiceForm.valid) {
      const invoice: Invoice = this.invoiceForm.value;

      if (this.isEdit) {
        invoice.invoiceId = this.invoiceId;
        this.invoiceService.updateInvoice(this.invoiceId, invoice).subscribe(() => {
          alert("Invoice edited.");
          this.router.navigate(['/invoice/invoices']);
        },err=>{
          alert(err.error);
        });
      } else {
        this.invoiceService.addInvoice(invoice).subscribe(() => {
          alert("Invoice added.");
          this.router.navigate(['/invoice/invoices']);
        }, err => {
          console.log(err);
          alert(err.error);
        });
      }
    }
  }
}
