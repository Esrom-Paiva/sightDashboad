import { Component, OnInit } from '@angular/core';
import { SalesDataService } from './../../services/sales-data.service';

@Component({
  selector: 'app-section-sales',
  templateUrl: './section-sales.component.html',
  styleUrls: ['./section-sales.component.css']
})
export class SectionSalesComponent implements OnInit {

  salesDataByCustomer: any;
  salesDataByState: any;
  constructor(private salesDataService: SalesDataService) { }

  ngOnInit(): void {
    this.salesDataService.getOrdersByState().subscribe(res => {
      this.salesDataByState = res;
    });

    this.salesDataService.getOrdersByCustumer(5).subscribe(res => {
      this.salesDataByCustomer = res;
    });
  }

}
