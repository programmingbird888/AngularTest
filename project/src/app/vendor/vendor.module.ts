import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { VendorRoutingModule } from './vendor-routing.module';
import { VendorComponent } from './vendor.component';
import { VendorListComponent } from '../components/vendor-list/vendor-list.component';
import { VendorDetailComponent } from '../components/vendor-detail/vendor-detail.component';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    VendorComponent,
    VendorListComponent,
    VendorDetailComponent
  ],
  imports: [
    CommonModule,
    VendorRoutingModule,
    HttpClientModule,
    ReactiveFormsModule
  ]
})
export class VendorModule { }
