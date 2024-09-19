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
  invoiceNumber: string | null = null;
  vendorlist: Vendor[] = [];
  currencylist: Currency[] = [];

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
      invoiceCurrencyCode: ['', Validators.required],
      invoiceDueDate: ['', Validators.required],
      vendorCode: ['', Validators.required],
      isActive: [true]
    });
  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.invoiceNumber = params['invoiceNumber'];
      if (this.invoiceNumber) {
        this.loadInvoice(this.invoiceNumber);
        this.isEdit = true;
      }
    });
    this.vendorService.getVendors().subscribe(v=>this.vendorlist = v);
    this.currencyService.getCurrencies().subscribe(v=>this.currencylist = v);
  }

  loadInvoice(invoiceNumber: string): void {
    this.invoiceService.getInvoice(invoiceNumber).subscribe(invoice => {
      this.invoiceForm.patchValue(invoice);
    });
  }

  onSubmit(): void {
    if (this.invoiceForm.valid) {
      const invoice: Invoice = this.invoiceForm.value;
      if (this.isEdit) {
        this.invoiceService.updateInvoice(this.invoiceNumber!, invoice).subscribe(() => {
          this.router.navigate(['/invoices']);
        },err=>{
          alert(err.error);
        });
      } else {
        this.invoiceService.addInvoice(invoice).subscribe(() => {
          this.router.navigate(['/invoices']);
        },err=>{
          alert(err.error);
        });
      }
    }
  }
}
