import { AreaViewManagerInterface } from './../../Models/area-viewManager-interface';
import { Component, OnInit } from '@angular/core';
import { DataAreaViewManagerSercvice } from 'src/app/services/data-areaViewManager.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-area-view-manager',
  templateUrl: './area-view-manager.component.html',
  styleUrls: ['./area-view-manager.component.css']
})
export class AreaViewManagerComponent implements OnInit {

  areaId: string;
  private sub: any;
  private areaManagers: AreaViewManagerInterface

  constructor(private dataAreaView: DataAreaViewManagerSercvice, 
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      this.areaId = params['id']; 
   });
    this.dataAreaView.getManagerByArea(this.areaId).subscribe((areaManagers: AreaViewManagerInterface) => (this.areaManagers = areaManagers));
  }

}
