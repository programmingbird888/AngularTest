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
  currencyId: number = 0;

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
      this.currencyId = params['currencyId'];
      if (this.currencyId) {
        this.loadCurrency(this.currencyId);
        this.isEdit = true;
      }
    });
  }

  loadCurrency(currencyId : number): void {
    this.currencyService.getCurrency(currencyId).subscribe(currency => {
      this.currencyForm.patchValue(currency);
    });
  }

  onSubmit(): void {
    if (this.currencyForm.valid) {
      const currency: Currency = this.currencyForm.value;
      if (this.isEdit) {
        currency.currencyId = this.currencyId;
        this.currencyService.updateCurrency(this.currencyId!, currency).subscribe(() => {
          alert("Currency edited.");
          this.router.navigate(['/currency/currencies']);
        },err=>{
          alert(err.error);
        });
      } else {
        this.currencyService.addCurrency(currency).subscribe(() => {
          alert("Currency added.");
          this.router.navigate(['/currency/currencies']);
        },err=>{
          alert(err.error);
        });
      }
    }
  }
}
