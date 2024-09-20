import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { VendorRoutingModule } from './vendor-routing.module';
import { VendorComponent } from './vendor.component';
import { VendorListComponent } from './vendorlist/vendorlist.component';
import { VendordetailComponent } from './vendordetail/vendordetail.component';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    VendorComponent,
    VendorListComponent,
    VendordetailComponent
  ],
  imports: [
    CommonModule,
    VendorRoutingModule,
    HttpClientModule,
    ReactiveFormsModule
  ]
})
export class VendorModule { }
