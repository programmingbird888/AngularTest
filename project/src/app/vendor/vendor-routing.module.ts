import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { VendorComponent } from './vendor.component';
import { VendorListComponent } from '../components/vendor-list/vendor-list.component';
import { VendorDetailComponent } from '../components/vendor-detail/vendor-detail.component';

const routes: Routes = [
  { path: '', component: VendorComponent },

  { path: 'vendors', component: VendorListComponent },
  { path: 'vendors/new', component: VendorDetailComponent },
  { path: 'vendors/edit/:vendorId', component: VendorDetailComponent },

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class VendorRoutingModule { }
