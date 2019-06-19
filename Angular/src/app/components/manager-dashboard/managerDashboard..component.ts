import { Component, OnInit } from '@angular/core';
import {IndicatorDetail} from '../../Models/IndicatorDetail'
import { ManagerService } from '../../Services/Manager.service';

@Component({
  selector: 'app-indicators-list',
  templateUrl: './ManagerDashboard.component.html',
  styleUrls: ['./ManagerDashboard.component.css']
})
export class ManagerDashboardComponent implements OnInit {

  pageTitle: string = "Indicators list"
  showColorsDetails: boolean = false;
  indicators: Array<IndicatorDetail>;

  constructor(private _serviceManager: ManagerService) { }

  ngOnInit() {
    this._serviceManager.getAreasByManager("dd60997e-3764-47d3-b680-665537f2a1ea").subscribe(
      ((data : Array<IndicatorDetail>) => this.result(data)),
      ((error : any) => console.log(error))      
    )
  }
  
  private result(data: Array<IndicatorDetail>):void {
    this.indicators = data;
    console.log(this.indicators);
  }

  toggleColorsDetails(): void {
  this.showColorsDetails = !this.showColorsDetails;
}

}
