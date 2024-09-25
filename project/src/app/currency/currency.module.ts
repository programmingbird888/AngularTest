import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CurrencyRoutingModule } from './currency-routing.module';
import { CurrencyComponent } from './currency.component';
import { CurrencyListComponent } from '../components/currency-list/currency-list.component';
import { CurrencyDetailComponent } from '../components/currency-detail/currency-detail.component';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    CurrencyComponent,
    CurrencyListComponent,
    CurrencyDetailComponent
  ],
  imports: [
    CommonModule,
    CurrencyRoutingModule,
    HttpClientModule,
    ReactiveFormsModule
  ]
})
export class CurrencyModule { }
