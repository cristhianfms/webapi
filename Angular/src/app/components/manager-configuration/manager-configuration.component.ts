import { AuthorizationService } from './../../services/authorization.service';
import { Component, OnInit } from '@angular/core';
import {IndicatorDetail} from '../../Models/IndicatorDetail'
import { ManagerService } from '../../services/manager.service';
import { IndicatorConfig } from 'src/app/Models/IndicatorConfig';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-manager-configuration',
  templateUrl: './manager-configuration.component.html',
  styleUrls: ['./manager-configuration.component.css']
})
export class ManagerConfigurationComponent implements OnInit {
  pageTitle : string = "Dashboard customization"
  private indicators: Array<IndicatorDetail>;

  constructor(private _serviceManager: ManagerService,private authService: AuthorizationService) { }

  ngOnInit() {
    let userId = this.authService.getUserId()
    this._serviceManager.getAreasByManager(userId).subscribe(
      ((data : Array<IndicatorDetail>) => this.result(data)),
      ((error : any) => console.log(error))      
    )
  }
  onPreUpdateIndicator(indicator: IndicatorConfig): void {
    console.log('entre al metodo nPreUpdateInicator')
    console.log(indicator)
    //console.log('Objeto asignado: ' + Object.assign({},indicator))
    this._serviceManager.selectedIndicator = Object.assign({},indicator);
    console.log('customName: ' + indicator.customName)
    console.log('id: ' + indicator.id)
    console.log('position: ' + indicator.position)
    console.log('visible: ' + indicator.visible)
    console.log('selected indicator: '+this._serviceManager.selectedIndicator)
    console.log('selected indicator.id: '+this._serviceManager.selectedIndicator.id)
    /*this._serviceManager.selectedIndicator.customName = indicator.customName;
    this._serviceManager.selectedIndicator.id = indicator.id;
    this._serviceManager.selectedIndicator.position = indicator.position;
    this._serviceManager.selectedIndicator.visible = indicator.visible;
    console.log('selected indicator: '+this._serviceManager.selectedIndicator)*/
  }

  private result(data: Array<IndicatorDetail>):void {
    this.indicators = data;
    console.log(this.indicators);
  }

  /*resetForm(dashboardForm?:NgForm): void {
    this._serviceManager.selectedIndicator = {
      Id:null,
      Position:0,
      Visible:true,
      CustomName:''
    };
  }*/



 /* saveConfig(): void{

    this._serviceManager.updateIndicatorConfig("73ad18c1-e54c-4c96-aa23-c03df8c674e5",)
  }*/
}
