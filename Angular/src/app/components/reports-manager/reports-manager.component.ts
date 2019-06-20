import { ReportsManagerInterface } from 'src/app/Models/reports-manager-interface';
import { AuthorizationService } from './../../services/authorization.service';
import { Component, OnInit } from '@angular/core';
import {ReportsManagerService} from './../../services/report-manager.service';


@Component({
  selector: 'app-reports-manager',
  templateUrl: './reports-manager.component.html',
  styleUrls: ['./reports-manager.component.css']
})
export class ReportsManagerComponent implements OnInit {

  constructor(private dataReports: ReportsManagerService, private authService: AuthorizationService) {
    this.dataReports.getReport(authService.getUserId()).subscribe(data => {
      console.log(data)
      });
   }
private reports: ReportsManagerInterface

  ngOnInit() {
    let userId = this.authService.getUserId()
    console.log(userId + ' Userid')
    this.dataReports.getReport(userId).subscribe((reports: ReportsManagerInterface) => (this.reports = reports));
  }

}
