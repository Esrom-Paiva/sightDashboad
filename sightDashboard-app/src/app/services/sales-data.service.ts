import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SalesDataService {

  constructor(private http: HttpClient) {}
  url = 'http://localhost:50882/api/order';

    getOrders(pageIndex: number, pageSize: number): Observable<any>{
      return this.http.get<any>(`${this.url}/${pageIndex}/${pageSize}`);
    }

    getOrdersByCustumer(n: number): Observable<any>{
      return this.http.get<any>(`${this.url}/ByCustomer/${n}`);
    }

    getOrdersByState(): Observable<any>{
      return this.http.get<any>(`${this.url}/ByState`);
    }
}
