import { Component, OnInit } from '@angular/core';
import { DataReportsMoreLoggedService } from './../../services/data-report-more-logged.service';
import { DataService } from './../../services/data.service';
import { ReportMoreLoggedInterface } from 'src/app/Models/report-more-logged-interface';
import { LineToLineMappedSource } from 'webpack-sources';

@Component({
  selector: 'app-report-more-logged',
  templateUrl: './report-more-logged.component.html',
  styleUrls: ['./report-more-logged.component.css']
})
export class ReportMoreLoggedComponent implements OnInit {

  constructor(private dataService: DataReportsMoreLoggedService) { 
    this.dataService.getReportsMoreLogged().subscribe(data => {
      console.log("data: " + data)
      });
  }
  private reports: any;
  ngOnInit() {
    this.dataService.getReportsMoreLogged().subscribe(data => (this.reports = data));
  }
}
