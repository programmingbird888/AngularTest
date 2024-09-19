import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CurrencyService } from '../../services/currency.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Currency } from '../../models/currency.model';

@Component({
  selector: 'app-currency-detail',
  templateUrl: './currency-detail.component.html',
})
export class CurrencyDetailComponent implements OnInit {
  currencyForm: FormGroup;
  isEdit: boolean = false;
  currencyCode: string | null = null;

  constructor(
    private fb: FormBuilder,
    private currencyService: CurrencyService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.currencyForm = this.fb.group({
      currencyCode: ['', Validators.required],
      currencyName: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.currencyCode = params['currencyCode'];
      if (this.currencyCode) {
        this.loadCurrency(this.currencyCode);
        this.isEdit = true;
      }
    });
  }

  loadCurrency(currencyCode: string): void {
    this.currencyService.getCurrency(currencyCode).subscribe(currency => {
      this.currencyForm.patchValue(currency);
    });
  }

  onSubmit(): void {
    if (this.currencyForm.valid) {
      const currency: Currency = this.currencyForm.value;
      if (this.isEdit) {
        this.currencyService.updateCurrency(this.currencyCode!, currency).subscribe(() => {
          this.router.navigate(['/currencies']);
        },err=>{
          alert(err.error);
        });
      } else {
        this.currencyService.addCurrency(currency).subscribe(() => {
          this.router.navigate(['/currencies']);
        },err=>{
          alert(err.error);
        });
      }
    }
  }
}
