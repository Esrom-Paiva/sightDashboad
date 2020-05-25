import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-pie-chart',
  templateUrl: './pie-chart.component.html',
  styleUrls: ['./pie-chart.component.css']
})
export class PieChartComponent implements OnInit {

  constructor() { }

  pieChartData: number[] = [350, 460, 120, 200];
  pieChartLabels: string[] = ['ZXC Logistics', 'Main st Bakery', 'Acme Hosting'];
  colors: any[] = [
    {
      backgroundColor: ['#26547c', '#ff6b6b', '#ffd166']
    }
  ];
  pieChartType = 'doughnut';

  ngOnInit(): void {
  }

}
