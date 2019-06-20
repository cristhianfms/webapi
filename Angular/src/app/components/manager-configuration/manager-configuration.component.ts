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
    this._serviceManager.selectedIndicator = Object.assign({},indicator);
  }

  private result(data: Array<IndicatorDetail>):void {
    this.indicators = data;
    console.log(this.indicators);
  }
}
