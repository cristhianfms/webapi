import { Component, OnInit } from '@angular/core';
import { AreaInterface } from 'src/app/Models/area-interface';
import { ActivatedRoute } from '@angular/router';
import { DataAreaService } from 'src/app/services/dataArea.service';
import {ConditionComponent} from '../condition/condition.component';

@Component({
  selector: 'app-area-viewindicators',
  templateUrl: './area-viewindicators.component.html',
  styleUrls: ['./area-viewindicators.component.css']
})
export class AreaViewindicatorsComponent implements OnInit {

  pageTitle:string = "AREA'S INDICATORS"
  areaId: string;
  private sub: any;
  indicators: Array<Object>;


  constructor(private route: ActivatedRoute, private _dataAreaService: DataAreaService) {}

  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
       this.areaId = params['id']; 
    });

    this._dataAreaService.getAllAreaIndicators(this.areaId).subscribe(
      ((data : Array<Object>) => this.result(data)),
      ((error : any) => console.log(error))      
    )
  }
  
  private result(data: Array<Object>):void {
    this.indicators = data;
    console.log(this.indicators);
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }
}
