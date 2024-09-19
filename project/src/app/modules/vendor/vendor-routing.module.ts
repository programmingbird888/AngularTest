import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { VendorComponent } from './vendor.component';
import { VendorListComponent } from 'src/app/components/vendor-list/vendor-list.component';
import { VendorDetailComponent } from 'src/app/components/vendor-detail/vendor-detail.component';

const routes: Routes = [
  { path: '', component: VendorComponent },

  // { path: '', redirectTo: 'modules/vendors', pathMatch: 'full' }

  { path: 'vendors', component: VendorListComponent },
  { path: 'vendors/new', component: VendorDetailComponent },
  { path: 'vendors/edit/:vendorCode', component: VendorDetailComponent }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class VendorRoutingModule { }
