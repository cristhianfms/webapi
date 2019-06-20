import { NgForm } from '@angular/forms';
import { AreaInterface } from './../../Models/area-interface';
import { DataAreaService } from './../../services/dataArea.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-areas',
  templateUrl: './areas.component.html',
  styleUrls: ['./areas.component.css']
})
export class AreasComponent implements OnInit {

  constructor(private dataService: DataAreaService) { 
    this.dataService.getAllAreas().subscribe(data => {
      console.log(data)
      });
  }
  private areas:AreaInterface;

  ngOnInit() {
    this.dataService.getAllAreas().subscribe((areas: AreaInterface) => (this.areas = areas));
  }
  
  onDeleteArea(id:string): void {
    if(confirm('Are you sure to delete?')){
      this.dataService.DeleteArea(id).subscribe();
    }
  }
  
  onPreUpdateArea(area: AreaInterface): void {
    this.dataService.selectedArea = Object.assign({},area);
  }
  
  resetForm(areaForm?:NgForm): void {
    this.dataService.selectedArea = {
      Id:null,
      Name:'',
      ConnectionString:''
    };
  }
}
