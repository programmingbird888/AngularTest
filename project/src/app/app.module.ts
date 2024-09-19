import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { VendorListComponent } from './components/vendor-list/vendor-list.component';
import { VendorDetailComponent } from './components/vendor-detail/vendor-detail.component';
import { CurrencyListComponent } from './components/currency-list/currency-list.component';
import { CurrencyDetailComponent } from './components/currency-detail/currency-detail.component';
import { InvoiceListComponent } from './components/invoice-list/invoice-list.component';
import { InvoiceDetailComponent } from './components/invoice-detail/invoice-detail.component';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    // VendorListComponent,
    // VendorDetailComponent,
    CurrencyListComponent,
    CurrencyDetailComponent,
    // InvoiceListComponent,
    // InvoiceDetailComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
