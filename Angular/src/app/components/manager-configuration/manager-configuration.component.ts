import { Component, OnInit } from '@angular/core';
import {IndicatorDetail} from '../../Models/IndicatorDetail'
import { ManagerService } from '../../Services/Manager.service';

@Component({
  selector: 'app-manager-configuration',
  templateUrl: './manager-configuration.component.html',
  styleUrls: ['./manager-configuration.component.css']
})
export class ManagerConfigurationComponent implements OnInit {
  pageTitle : string = "Dashboard customization"
  indicators: Array<IndicatorDetail>;

  constructor(private _serviceManager: ManagerService) { }

  ngOnInit() {
    this._serviceManager.getAreasByManager("73ad18c1-e54c-4c96-aa23-c03df8c674e5").subscribe(
      ((data : Array<IndicatorDetail>) => this.result(data)),
      ((error : any) => console.log(error))      
    )
  }
  
  private result(data: Array<IndicatorDetail>):void {
    this.indicators = data;
    console.log(this.indicators);
  }



 /* saveConfig(): void{

    this._serviceManager.updateIndicatorConfig("73ad18c1-e54c-4c96-aa23-c03df8c674e5",)
  }*/
}
