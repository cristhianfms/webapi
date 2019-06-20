import { DataReportsService } from './../../services/dataReports.service';
import { DataService } from './../../services/data.service';
import { Component, OnInit } from '@angular/core';
import { ReportsInterface } from 'src/app/Models/reports-interface';

@Component({
  selector: 'app-reports',
  templateUrl: './reports.component.html',
  styleUrls: ['./reports.component.css']
})
export class ReportsComponent implements OnInit {

  constructor(private dataService: DataReportsService) { 
    this.dataService.getIndicatorsMoreHidden().subscribe(data => {
      console.log(data)
      });
  }
  private reports: ReportsInterface
  ngOnInit() {
    this.dataService.getIndicatorsMoreHidden().subscribe((reports: ReportsInterface) => (this.reports = reports));
  }
}
