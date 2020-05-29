import { Order } from './../../shared/order';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-section-orders',
  templateUrl: './section-orders.component.html',
  styleUrls: ['./section-orders.component.css']
})
export class SectionOrdersComponent implements OnInit {

  constructor() { }
  orders: Order[] = [
    {id: 1, customer:
      {id: 1, name: 'Main St Bakery', state: 'CO',  email: 'Test@gmail.com'},
      amount: 230, placed: new Date(2020, 5, 28), fulfilled: new Date(2020, 5, 28)},
    {id: 2, customer:
      {id: 2, name: 'Main St Bakery', state: 'CO',  email: 'Test@gmail.com'},
      amount: 230, placed: new Date(2020, 5, 28), fulfilled: new Date(2020, 5, 28)},
    {id: 3, customer:
      {id: 3, name: 'Main St Bakery', state: 'CO',  email: 'Test@gmail.com'},
      amount: 230, placed: new Date(2020, 5, 28), fulfilled: new Date(2020, 5, 28)},
    {id: 4, customer:
      {id: 4, name: 'Main St Bakery', state: 'CO',  email: 'Test@gmail.com'},
      amount: 230, placed: new Date(2020, 5, 28), fulfilled: new Date(2020, 5, 28)},
    {id: 5, customer:
      {id: 5, name: 'Main St Bakery', state: 'CO',  email: 'Test@gmail.com'},
      amount: 230, placed: new Date(2020, 5, 28), fulfilled: new Date(2020, 5, 28)},
  ];

  ngOnInit(): void {
  }

}

