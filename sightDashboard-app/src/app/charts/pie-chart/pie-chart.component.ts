import { Component, OnInit, Input } from '@angular/core';
import {THEME_COLORS} from '../../shared/theme.colors';
import _ from 'lodash';

const theme = 'Bright';

@Component({
  selector: 'app-pie-chart',
  templateUrl: './pie-chart.component.html',
  styleUrls: ['./pie-chart.component.css']
})
export class PieChartComponent implements OnInit {

  constructor() { }

    @Input() inputData: any;
    @Input() limit: any;
    pieChartData: number[];
    pieChartLabels: string[];
    colors: any[] = [
    {
      backgroundColor: this.themeColors(theme)
    }
  ];
  pieChartType = 'doughnut';

  ngOnInit(): void {
    this.parseChartData(this.inputData, this.limit);
  }
  parseChartData(res: any, limit?: number){
    const allData = res.slice(0, limit);
    this.pieChartData = allData.map(pcd => _.values(pcd)[1]);
    this.pieChartLabels = allData.map(pcl => _.values(pcl)[0]);
  }

  themeColors(setName: string): string[] {
    const color = THEME_COLORS.slice(1)
    .find(set => set.name === setName).colorSet;

    return color;
  }
}
