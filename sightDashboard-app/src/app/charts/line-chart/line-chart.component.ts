import { SalesDataService } from './../../services/sales-data.service';
import { Component, OnInit } from '@angular/core';
import { LINE_CHART_COLORS } from '../../shared/chart.colors';
import * as moment from 'moment';

@Component({
  selector: 'app-line-chart',
  templateUrl: './line-chart.component.html',
  styleUrls: ['./line-chart.component.css']
})
export class LineChartComponent implements OnInit {

  constructor(private salesDataService: SalesDataService) { }

  topCustomers: string[];
  allOrders: any[];

  lineChartData: any;
  lineChartLabels: any;
  lineChartOptions: any = {
    Responsive: true,
    maintainAspectRatio: false
  };
  lineChartLegend: true;
  lineChartType = 'line';
  lineChartColors = LINE_CHART_COLORS;

  ngOnInit(): void {
    this.salesDataService.getOrders(1, 1000).subscribe(res => {
        this.allOrders = res.data.data;

        this.salesDataService.getOrdersByCustumer(3).subscribe(cust => {
          this.topCustomers = cust.map(x => x.data);
          const allChartData = this.topCustomers.reduce((result, index) => {
            result.push(this.getChartData(this.allOrders, index));
            return result;
          }, []);

          let dates = allChartData.map(d => d.data).reduce((ret, index) => {
            ret.push(index.map( i => new Date(i[0])));
            return ret;
          });
          dates =[].concat.apply([],dates);
          
          const CustomerOrdersByDate = this.getCustomerOrdersByDate(allChartData, dates)['data'];
          console.log('CustomerOrdersByDate', CustomerOrdersByDate);
  
          this.lineChartLabels = CustomerOrdersByDate[0]['orders'].map(o => o['date']);
          
          this.lineChartData = [
            {'data': CustomerOrdersByDate[0].orders.map(x => x.total),'label': CustomerOrdersByDate[0].customer},
            {'data': CustomerOrdersByDate[1].orders.map(x => x.total),'label': CustomerOrdersByDate[1].customer},
            {'data': CustomerOrdersByDate[2].orders.map(x => x.total),'label': CustomerOrdersByDate[2].customer},
          ];
        });
    });
  }

  getChartData(allOrders: any, name: string){
    const customerOrders = allOrders.filter(co => co.customer.name === name);

    const formattedOrders = customerOrders.reduce((ret, co) => {
      ret.push([co.placed, co.total]);
      return ret;
    }, []);

    return { customer: name, data: formattedOrders};
  }

  getCustomerOrdersByDate(orders: any, dates: any){
    const customers = this.topCustomers;
    const prettyDates = dates.map(p => this.toFriendlyDate(p)).sort();

    const date = Array.from(new Set(prettyDates)).sort();
    const result = {};
    const dataSet = result['data'] = [];
    customers.reduce((acc, cur, index) => {
      const customerOrders = [];
      dataSet[index] = {
        customer: cur, orders: 
        date.reduce((ac, cc, i) =>{
          const obj = {};
          obj['date'] = cc;
          obj['total'] = this.getCustomerDateTotal(cur, cc);
          customerOrders.push(obj);
          return customerOrders;
        })
      }      
      
      return acc
    }, []);

    return result;
  }

  getCustomerDateTotal(customer: string, date: any){
    const dateTotal = this.allOrders
                            .filter(c => c.customer.name === customer
                            && this.toFriendlyDate(c.placed) === date);

    const result = dateTotal.reduce((acc, cur) => {
      return acc + cur.total;
    },0);  
    return result;
  }

  toFriendlyDate(date: Date){
    return moment(date).endOf('day').format('YY-MM-DD');
  }
}
