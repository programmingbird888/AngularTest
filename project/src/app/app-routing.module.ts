import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { VendorListComponent } from './components/vendor-list/vendor-list.component';
import { VendorDetailComponent } from './components/vendor-detail/vendor-detail.component';
import { CurrencyDetailComponent } from './components/currency-detail/currency-detail.component';
import { CurrencyListComponent } from './components/currency-list/currency-list.component';
import { InvoiceListComponent } from './components/invoice-list/invoice-list.component';
import { InvoiceDetailComponent } from './components/invoice-detail/invoice-detail.component';

const routes: Routes = [
  // { path: 'vendors', component: VendorListComponent },
  // { path: 'vendors/new', component: VendorDetailComponent },
  // { path: 'vendors/edit/:vendorCode', component: VendorDetailComponent },

  // { path: 'invoices', component: InvoiceListComponent },
  // { path: 'invoices/new', component: InvoiceDetailComponent },
  // { path: 'invoices/edit/:invoiceId', component: InvoiceDetailComponent },

  // { path: 'currencies', component: CurrencyListComponent },
  // { path: 'currencies/new', component: CurrencyDetailComponent },
  // { path: 'currencies/edit/:currencyCode', component: CurrencyDetailComponent },
  
  { path: '', redirectTo: 'vendor/vendors', pathMatch: 'full' },
  { path: 'vendor', loadChildren: () => import('./vendor/vendor.module').then(m => m.VendorModule) },
  { path: 'invoice', loadChildren: () => import('./invoice/invoice.module').then(m => m.InvoiceModule) },
  { path: 'currency', loadChildren: () => import('./currency/currency.module').then(m => m.CurrencyModule) },
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
