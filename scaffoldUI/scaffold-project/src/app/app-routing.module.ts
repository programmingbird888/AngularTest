import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { VendorListComponent } from './vendor/vendorlist/vendorlist.component';
import { VendordetailComponent } from './vendor/vendordetail/vendordetail.component';

const routes: Routes = [

  // { path: 'vendors', component: VendorListComponent },
  // { path: 'vendors/new', component: VendordetailComponent },
  // { path: 'vendors/edit/:vendorCode', component: VendordetailComponent },

  // { path: 'invoices', component: InvoiceListComponent },
  // { path: 'invoices/new', component: InvoiceDetailComponent },
  // { path: 'invoices/edit/:invoiceNumber', component: InvoiceDetailComponent },

  // { path: 'currencies', component: CurrencyListComponent },
  // { path: 'currencies/new', component: CurrencyDetailComponent },
  // { path: 'currencies/edit/:currencyCode', component: CurrencyDetailComponent },
  
  // { path: '', redirectTo: '/vendors', pathMatch: 'full' },

  { path: 'vendor', loadChildren: () => import('./vendor/vendor.module').then(m => m.VendorModule) },


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
