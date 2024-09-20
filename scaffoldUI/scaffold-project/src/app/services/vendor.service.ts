import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Vendor } from '../Models/vendor';

@Injectable({
  providedIn: 'root'
})
export class VendorService {
  private apiUrl = 'https://localhost:7082/api/vendor'; 

  constructor(private http: HttpClient) {}

  getVendors(): Observable<Vendor[]> {
    return this.http.get<Vendor[]>(`${this.apiUrl}` + "/vendorlist");
  }

  getVendor(vendorCode: string): Observable<Vendor> {
    return this.http.get<Vendor>(`${this.apiUrl}/${vendorCode}` + "vendorbycode");
  }

  addVendor(vendor: Vendor): Observable<Vendor> {
    return this.http.post<Vendor>(`${this.apiUrl}` + "/createvendor", vendor);
  }

  updateVendor(vendorCode: string, vendor: Vendor): Observable<Vendor> {
    return this.http.put<Vendor>(`${this.apiUrl}` + "/updatevendor", vendor);
  }

  deleteVendor(vendorCode: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${vendorCode}` + "deletevendor");
  }
}
