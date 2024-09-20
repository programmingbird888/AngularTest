import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { VendorComponent } from './vendor.component';
import { VendorListComponent } from './vendorlist/vendorlist.component';
import { VendordetailComponent } from './vendordetail/vendordetail.component';

const routes: Routes = [
  { path: '', component: VendorComponent },

  { path: 'vendors', component: VendorListComponent },
  { path: 'vendors/new', component: VendordetailComponent },
  { path: 'vendors/edit/:vendorCode', component: VendordetailComponent },

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class VendorRoutingModule { }
