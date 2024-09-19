import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InvoiceComponent } from './invoice.component';
import { InvoiceListComponent } from 'src/app/components/invoice-list/invoice-list.component';
import { InvoiceDetailComponent } from 'src/app/components/invoice-detail/invoice-detail.component';

const routes: Routes = [
  { path: '', component: InvoiceComponent },

  { path: 'invoices', component: InvoiceListComponent },
  { path: 'invoices/new', component: InvoiceDetailComponent },
  { path: 'invoices/edit/:invoiceNumber', component: InvoiceDetailComponent },

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class InvoiceRoutingModule { }
