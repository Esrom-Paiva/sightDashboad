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

  constructor( private salesData: SalesDataService) { }
  orders: Order[];
  totalOrders: number;
  page = 1;
  limit = 10;
  loading = false;

  ngOnInit(): void {
    this.getOrders();
  }

  getOrders(): void {
    this.salesData.getOrders(this.page, this.limit)
      .subscribe(res => {
        console.log('Result from getOrders: ', res.data.total);
        this.orders = res.data.data;
        this.totalOrders = res.data.total;
        this.loading = false;
      });
  }
  goToPrevious(): void {
    if (this.page > 1){
      this.page--;
      this.getOrders();
    }
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
