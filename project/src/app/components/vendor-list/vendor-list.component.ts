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
  totalCount: number = 0;
  currentPage: number = 1;
  pageSize: number = 5;
  totalPages: number = 0;

  constructor(private vendorService: VendorService, private routes:Router) {}

  ngOnInit(): void {
    this.loadVendors();
  }

  loadVendors(): void {
  this.vendorService.getVendors(this.currentPage, this.pageSize).subscribe(
    response => {
      if (response && response.vendors) {
        this.vendors = response.vendors;
        this.totalCount = response.totalCount;
        this.totalPages = response.totalPages;
      }
    }
  );
}

  changePage(page: number): void {
    this.currentPage = page;
    this.loadVendors();
  }
  
  // loadVendors(): void {
  //   this.vendorService.getVendors(this.currentPage, this.pageSize).subscribe(
  //     response => {
  //       this.vendors = response.vendors;
  //       this.totalCount = response.totalCount;
  //       this.totalPages = response.totalPages;
  //     },
  //     error => {
  //       console.error('Error fetching vendors', error);
  //     }
  //   );
  // }

  // loadVendors(): void {
  //   this.vendorService.getVendors().subscribe(vendors => {
  //     this.vendors = vendors;
  //   });
  // }

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
