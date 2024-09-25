import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Vendor } from 'src/app/Models/vendor';
import { VendorService } from 'src/app/services/vendor.service';
import * as XLSX from 'xlsx';

@Component({
  selector: 'app-vendordetail',
  templateUrl: './vendordetail.component.html',
  styleUrls: ['./vendordetail.component.css']
})
export class VendordetailComponent implements OnInit{
  vendorForm: FormGroup;
  isEdit: boolean = false;
  vendorId: number | null = null;

  constructor(
    private fb: FormBuilder,
    private vendorService: VendorService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.vendorForm = this.fb.group({
      vendorCode: [ '', Validators.required],
      vendorLongName: ['', [Validators.required, Validators.pattern('^[a-zA-Z ]+$')]],
      vendorPhoneNumber: ['', [Validators.required, Validators.pattern('^[0-9]{10}$')]],
      vendorEmail: ['', [Validators.required, Validators.email]],
      isActive: [true]
    });
  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.vendorId = params['vendorId'];
      if (this.vendorId) {
        this.loadVendor(this.vendorId);
        this.isEdit = true;
      }
    });
  }

  loadVendor(vendorId: number): void {
    this.vendorService.getVendor(vendorId).subscribe(vendor => {
      this.vendorForm.patchValue(vendor);
    },
      err => {
        console.error(err);
      }
    );
  }

  onSubmit(): void {
    if (this.vendorForm.valid) {
      const vendor: Vendor = this.vendorForm.value;
      if (this.isEdit) {
        this.vendorService.updateVendor(this.vendorId!, vendor).subscribe(() => {
          this.router.navigate(['/vendor/vendors']);
        },err=>{
          alert(err.error);
        });
      } else {
        this.vendorService.addVendor(vendor).subscribe(() => {
          this.router.navigate(['/vendor']);
        },err=>{
          alert(err.error);
          console.log(err);
        });
      }
    }
  }
}
