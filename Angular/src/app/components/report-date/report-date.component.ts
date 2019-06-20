import { DataReportsService } from './../../services/dataReports.service';
import { DateInterface } from './../../Models/date-interface';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ReportDateInterface } from 'src/app/Models/report-date-interface';

@Component({
  selector: 'app-report-date',
  templateUrl: './report-date.component.html',
  styleUrls: ['./report-date.component.css']
})
export class ReportDateComponent implements OnInit {

  constructor(private dataReportDate: DataReportsService, private router: Router) { }
  private date : DateInterface = {
    dateStart:"",
    dateEnd:"",
  };
  private reports : ReportDateInterface

  search(){
    return this.dataReportDate.getLogsBetweenDate(this.date.dateStart,this.date.dateEnd).subscribe((reports: ReportDateInterface) => (this.reports = reports));
  }
  ngOnInit() {
  }

}
