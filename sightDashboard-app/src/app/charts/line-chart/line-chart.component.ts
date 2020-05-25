import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-line-chart',
  templateUrl: './line-chart.component.html',
  styleUrls: ['./line-chart.component.css']
})
export class LineChartComponent implements OnInit {

  constructor() { }

  pieChartData: number[] = [350, 460, 120, 200];
  pieChartLabels: string[] = ['ZXC Logistics', 'Main st Bakery', 'Acme Hosting'];
  colors: any[] = [
    {
      backgroundColor: ['#26547c', '#ff6b6b', '#ffd166']
    }
  ];
  pieChartType = 'pie';
  ngOnInit(): void {
  }
}
