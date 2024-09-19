import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { InvoiceRoutingModule } from './invoice-routing.module';
import { InvoiceComponent } from './invoice.component';
import { InvoiceListComponent } from 'src/app/components/invoice-list/invoice-list.component';
import { InvoiceDetailComponent } from 'src/app/components/invoice-detail/invoice-detail.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';


@NgModule({
  declarations: [
    InvoiceComponent,
     InvoiceListComponent,
    InvoiceDetailComponent
  ],
  imports: [
    CommonModule,
    InvoiceRoutingModule,
    HttpClientModule,
    ReactiveFormsModule
  ]
})
export class InvoiceModule { }
