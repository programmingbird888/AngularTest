import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CurrencyComponent } from './currency.component';
import { CurrencyListComponent } from '../components/currency-list/currency-list.component';
import { CurrencyDetailComponent } from '../components/currency-detail/currency-detail.component';

const routes: Routes = [
  { path: '', component: CurrencyComponent },

  { path: 'currencies', component: CurrencyListComponent },
  { path: 'currencies/new', component: CurrencyDetailComponent },
  { path: 'currencies/edit/:currencyId', component: CurrencyDetailComponent },
  
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CurrencyRoutingModule { }
