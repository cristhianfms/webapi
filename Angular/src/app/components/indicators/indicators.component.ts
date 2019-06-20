import { NgForm } from '@angular/forms';
import { AreaInterface } from './../../Models/area-interface';
import { DataAreaService } from './../../services/dataArea.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-indicators',
  templateUrl: './indicators.component.html',
  styleUrls: ['./indicators.component.css']
})
export class IndicatorsComponent implements OnInit {

  constructor(private dataService: DataAreaService, 
    private _currentRoute: ActivatedRoute, private _router : Router) { 

    this.dataService.getAllAreas().subscribe(data => {
      console.log(data)
      });
  }
  private areas:AreaInterface;

  ngOnInit() {
    this.dataService.getAllAreas().subscribe((areas: AreaInterface) => (this.areas = areas));
  }
  
  routeareaviewindicators(areaId: string):void{
    this._router.navigate(['/areaviewindicators',`${areaId}`]);
  }

  routearaddindicators(areaId: string):void{
    this._router.navigate(['/areaaddindicators',`${areaId}`]);
  }

  routearviewmanagers(areaId: string):void{
    this._router.navigate(['/areaviewmanagers',`${areaId}`]);
  }

  routearaddmanagers(areaId: string):void{
    this._router.navigate(['/areaaddmanagers',`${areaId}`]);
  }

  resetForm(areaForm?:NgForm): void {
    this.dataService.selectedArea = {
      Id:null,
      Name:'',
      ConnectionString:''
    };
  }
}
