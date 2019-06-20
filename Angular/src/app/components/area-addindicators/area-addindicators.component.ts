import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { IndicatorAddInterface } from 'src/app/Models/indicator-add-interface';
import {AreaIndicatorService} from '../../Services/area-indicator.service'
import {AreaIndicatorJSON} from '../../Models/area-indicators.json'

@Component({
  selector: 'app-area-addindicators',
  templateUrl: './area-addindicators.component.html',
  styleUrls: ['./area-addindicators.component.css']
})
export class AreaAddindicatorsComponent implements OnInit {
  pageTitle:string = "ADD INDICATOR TO AREA"
  areaId: string;
  private sub: any;
  indicator:IndicatorAddInterface= {
    Name:"",
    GreenCondition:"",
    YellowCondition:"",
    RedCondition:""
  };

  constructor(private route: ActivatedRoute, private _dataAreaService: AreaIndicatorService) { }

  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
       this.areaId = params['id']; 
    });
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }

  addIndicator(){
    var json_indicator;
    json_indicator = new AreaIndicatorJSON();
    json_indicator.Name = this.indicator.Name;
    json_indicator.GreenCondition = JSON.parse(this.indicator.GreenCondition);
    json_indicator.YellowCondition = JSON.parse(this.indicator.YellowCondition);
    json_indicator.RedCondition = JSON.parse(this.indicator.RedCondition);
    
    this._dataAreaService.AddIndicatorToArea(this.areaId,json_indicator);
  }
}
