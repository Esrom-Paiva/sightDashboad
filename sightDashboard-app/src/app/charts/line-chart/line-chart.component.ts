import { from } from 'rxjs';
import { Component, OnInit } from '@angular/core';
import { LINE_CHART_COLORS } from '../../shared/chart.colors';

const LINE_CHART_SAMPLE_DATA: any[] = [
  {data: [32, 14, 46, 23, 12, 50], label: 'Sentiment Analysis'},
  {data: [10, 21, 32, 46, 49, 50], label: 'Image Recognition'},
  {data: [11, 10, 15, 19, 40, 26], label: 'Forecasting'},
];

const LINE_CHART_LABELS: string[] = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'jun'];

@Component({
  selector: 'app-line-chart',
  templateUrl: './line-chart.component.html',
  styleUrls: ['./line-chart.component.css']
})
export class LineChartComponent implements OnInit {

  constructor() { }

  lineChartData = LINE_CHART_SAMPLE_DATA;
  lineChartLabels = LINE_CHART_LABELS;
  lineChartOptions: any = {
    Responsive: true,
    maintainAspectRatio: false
  };
  lineChartLegend: true;
  lineChartType = 'line';
  lineChartColors = LINE_CHART_COLORS;
  ngOnInit(): void {
  }

}
