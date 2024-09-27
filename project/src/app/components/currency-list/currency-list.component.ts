import { Component, OnInit } from '@angular/core';
import { CurrencyService } from '../../services/currency.service';
import { Currency } from '../../models/currency.model';
import * as XLSX from 'xlsx';
import { Router } from '@angular/router';

@Component({
  selector: 'app-currency-list',
  templateUrl: './currency-list.component.html',
})
export class CurrencyListComponent implements OnInit {
  currencies: Currency[] = [];
  totalCount = 0;
  totalPages = 0;
  currentPage = 1;
  pageSize = 5;
  constructor(private currencyService: CurrencyService, private routes:Router) {}

  ngOnInit(): void {
    this.loadCurrencies();
  }

loadCurrencies(): void {
  this.currencyService.getCurrencies(this.currentPage,this.pageSize).subscribe(
    response => {
      if (response && response.currency) {
        console.log(response.currencies);
        this.currencies = response.currency;
        this.totalCount = response.totalCount;
        this.totalPages = response.totalPages;
      }
    }
  );
}

  // loadCurrencies(): void {
  //   this.currencyService.getCurrencies(this.currentPage, this.pageSize).subscribe(currencies => {
  //     this.currencies = currencies;
  //   });
  // }

  changePage(page:number): void {
    this.currentPage = page;
    this.loadCurrencies();
  }

  deleteCurrency(currencyId: number): void {
    const confirmDelete = confirm("Are you sure you want to delete!")
    if (confirmDelete) {
      this.currencyService.deleteCurrency(currencyId).subscribe(() => {
        alert("Currency Deleted.");
        this.loadCurrencies();
      });
    }
  }

  UpdateCurrency(currencyId : number){
    this.routes.navigate([`currency/currencies/edit/${currencyId}`]);
  }

  exportToExcel(): void {
    const ws = XLSX.utils.json_to_sheet(this.currencies);
    const wb = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb, ws, 'Currencies');
    XLSX.writeFile(wb, 'currencies.xlsx');
  }
}
