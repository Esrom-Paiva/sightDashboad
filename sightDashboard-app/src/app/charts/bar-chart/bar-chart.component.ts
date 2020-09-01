import { from } from 'rxjs';
import { Component, OnInit } from '@angular/core';
import { SalesDataService } from '../../services/sales-data.service';
import * as moment from 'moment';
// const SAMPLE_BARCHART_DATA: any[] = [
//   {data: [19, 25, 37, 40, 60, 90, 99], label: 'Q3 Sales'},
//   {data: [18, 29, 30, 55, 72, 79, 89], label: 'Q4 Sales'},
// ];
//const SAMPLE_BARCHART_LABELS: string[] = ['W1', 'W2', 'W3', 'W4', 'W5', 'W6', 'W7'];

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
