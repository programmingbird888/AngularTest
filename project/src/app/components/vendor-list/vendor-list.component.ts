import { Component, OnInit } from '@angular/core';
import { VendorService } from '../../services/vendor.service';
import * as XLSX from 'xlsx';
import { Router } from '@angular/router';
import { Vendor } from 'src/app/models/vendor.model';

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

  deleteVendor(vendorId: number): void {
    const confirmDelete = confirm("Are you sure you want to delete!")
    if (confirmDelete) {
      this.vendorService.deleteVendor(vendorId).subscribe(() => {
        alert("Vendor Deleted.");
        this.loadVendors();
      }, err => {
        console.log(err.error);
        alert(err.error);
      });
    }
  }

  UpdateVendor(vendorId:number){
    this.routes.navigate([`/vendor/vendors/edit/${vendorId}`]);
  }

  exportToExcel(): void {
    const ws = XLSX.utils.json_to_sheet(this.vendors);
    const wb = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb, ws, 'Vendors');
    XLSX.writeFile(wb, 'vendors.xlsx');
  }

}
