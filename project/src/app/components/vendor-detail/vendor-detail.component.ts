import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { VendorService } from '../../services/vendor.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Vendor } from '../../models/vendor.model';

@Component({
  selector: 'app-vendor-detail',
  templateUrl: './vendor-detail.component.html',
})
export class VendorDetailComponent implements OnInit {
  vendorForm: FormGroup;
  isEdit: boolean = false;
  vendorId: number = 0;
  submitted: boolean = false;

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
      this.vendorId = Number(params['vendorId']);
      if (this.vendorId) {
        this.loadVendor(this.vendorId);
        this.isEdit = true;
      }
    });
  }

  loadVendor(vendorId: number): void {
    this.vendorService.getVendor(vendorId).subscribe(vendor => {
      this.vendorForm.patchValue(vendor);
    });
  }

  onSubmit(): void {
    if (this.vendorForm.valid) {
      const vendor: Vendor = this.vendorForm.value;
      
      if (this.isEdit) {
        vendor.vendorId = this.vendorId;
        this.vendorService.updateVendor(this.vendorId, vendor).subscribe(() => {
          alert("Vendor edited.");
          this.router.navigate(['/vendor/vendors']);
        }, err => {
          console.log(err);
          alert(err.error);
        });
      } else {
        this.vendorService.addVendor(vendor).subscribe(() => {
          this.submitted = true;
          alert("Vendor Added.");
          this.router.navigate(['/vendor/vendors']);
        }, err => {
          console.log(err);
          alert(err);
        });
      }
    }
  }
}
