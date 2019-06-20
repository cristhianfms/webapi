import { Component, OnInit } from '@angular/core';
import {IndicatorDetail} from '../../Models/IndicatorDetail'
import { ManagerService } from '../../services/manager.service';
import {NgForm} from '@angular/forms';
import {Location} from '@angular/common';

@Component({
  selector: 'app-indicators-list',
  templateUrl: './ManagerDashboard.component.html',
  styleUrls: ['./ManagerDashboard.component.css']
})
export class ManagerDashboardComponent implements OnInit {

  pageTitle: string = "Indicators list"
  showColorsDetails: boolean = false;
  indicators: Array<IndicatorDetail>;

  constructor(private _serviceManager: ManagerService, private location: Location) { }

  ngOnInit() {
    this._serviceManager.getAreasByManager("73AD18C1-E54C-4C96-AA23-C03DF8C674E5").subscribe(
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
