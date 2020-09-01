import { from } from 'rxjs';
import { Component, OnInit } from '@angular/core';
import { SalesDataService } from '../../services/sales-data.service';
import * as moment from 'moment';

@Component({
  selector: 'app-bar-chart',
  templateUrl: './bar-chart.component.html',
  styleUrls: ['./bar-chart.component.css']
})
export class BarChartComponent implements OnInit {

  constructor(private salesDataService: SalesDataService) { }

  orders: any;
  orderLabels: number[];
  orderData: number[];

  public barChartData: any[];
  public barChartLabels: string[];
  public barChartType = 'bar';
  public barChatsLegend: false;
  public barChatsOptions: any = {
    scaleShowVerticalLines: false,
    responsive: true
  };

  ngOnInit(): void {
    this.salesDataService.getOrders(1, 100)
      .subscribe(res => {
        const localChartData = this.getChartData(res);
        this.barChartLabels = localChartData.map(x => x[0]).reverse();
        this.barChartData = [{'data': localChartData.map(x => x[1]), 'label': 'Sales'}];
      });
  }
  getChartData(res: Response){
    this.orders = res['data']['data'];

    const formattedOrders = this.orders.reduce((r, order) => {
      r.push([moment(order.placed).format('YYYY-MM-DD'), order.total]);
      return r;
    }, []);

    const p = [];

    const chartData = formattedOrders.reduce((r, formattedOrder) => {
      const key = formattedOrder[0];
      if (!p[key]){
        p[key] = formattedOrder;
        r.push(p[key]);
      }
      else{
        p[key][1] += formattedOrder[1];
      }
      return r;
    }, []);

    return chartData;
  }
}
