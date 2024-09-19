import { Component, OnInit } from '@angular/core';
import { VendorService } from '../../services/vendor.service';
import { Vendor } from '../../models/vendor.model';
import * as XLSX from 'xlsx';
import { Router } from '@angular/router';

@Component({
  selector: 'app-vendor-list',
  templateUrl: './vendor-list.component.html',
})
export class VendorListComponent implements OnInit {
  vendors: Vendor[] = [];

  constructor(private vendorService: VendorService, private routes:Router) {}

  ngOnInit(): void {
    this.loadVendors();
  }

  loadVendors(): void {
    this.vendorService.getVendors().subscribe(vendors => {
      this.vendors = vendors;
    });
  }

  deleteVendor(vendorCode: string): void {
    this.vendorService.deleteVendor(vendorCode).subscribe(() => {
      this.loadVendors();
    },err=>{
      alert(err.error);
    });
  }

  UpdateVendor(vendorCode:string){
    this.routes.navigate([`vendors/edit/${vendorCode}`]);
  }

  exportToExcel(): void {
    const ws = XLSX.utils.json_to_sheet(this.vendors);
    const wb = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb, ws, 'Vendors');
    XLSX.writeFile(wb, 'vendors.xlsx');
  }

}
