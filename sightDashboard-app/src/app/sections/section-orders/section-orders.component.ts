import { from } from 'rxjs';
import { Order } from './../../shared/order';
import { Component, OnInit } from '@angular/core';
import { SalesDataService } from '../../services/sales-data.service';

@Component({
  selector: 'app-section-orders',
  templateUrl: './section-orders.component.html',
  styleUrls: ['./section-orders.component.css']
})
export class SectionOrdersComponent implements OnInit {

  constructor( private _salesData: SalesDataService) { }
  // orders: Order[] = [
  //   {id: 1, customer:
  //     {id: 1, name: 'Main St Bakery', state: 'CO',  email: 'Test@gmail.com'},
  //     amount: 230, placed: new Date(2020, 5, 28), fulfilled: new Date(2020, 5, 28)},
  //   {id: 2, customer:
  //     {id: 2, name: 'Main St Bakery', state: 'CO',  email: 'Test@gmail.com'},
  //     amount: 230, placed: new Date(2020, 5, 28), fulfilled: new Date(2020, 5, 28)},
  //   {id: 3, customer:
  //     {id: 3, name: 'Main St Bakery', state: 'CO',  email: 'Test@gmail.com'},
  //     amount: 230, placed: new Date(2020, 5, 28), fulfilled: new Date(2020, 5, 28)},
  //   {id: 4, customer:
  //     {id: 4, name: 'Main St Bakery', state: 'CO',  email: 'Test@gmail.com'},
  //     amount: 230, placed: new Date(2020, 5, 28), fulfilled: new Date(2020, 5, 28)},
  //   {id: 5, customer:
  //     {id: 5, name: 'Main St Bakery', state: 'CO',  email: 'Test@gmail.com'},
  //     amount: 230, placed: new Date(2020, 5, 28), fulfilled: new Date(2020, 5, 28)},
  // ];
  orders: Order[];
  total = 0;
  page = 1;
  limit = 10;
  loading = false;

  ngOnInit(): void {
    this.getOrders();
  }

  getOrders(): void {
    this._salesData.getOrders(this.page, this.limit)
      .subscribe(res => {
        console.log('Result from getOrders: ', res.total, res.data);
        this.orders = res.data.data;
        this.total = res.data.total;
        this.loading = false;
      });
  }
  goToPrevious(): void {
    this.page--;
    this.getOrders();
  }
  goToNext(): void {
    this.page++;
    this.getOrders();
  }
  goToPage(page: number): void{
    this.page = page;
    this.getOrders();
  }
}
