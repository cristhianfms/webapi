import { AreaViewManagerInterface } from './../../Models/area-viewManager-interface';
import { Component, OnInit } from '@angular/core';
import { DataAreaViewManagerSercvice } from 'src/app/services/data-areaViewManager.service';

@Component({
  selector: 'app-area-view-manager',
  templateUrl: './area-view-manager.component.html',
  styleUrls: ['./area-view-manager.component.css']
})
export class AreaViewManagerComponent implements OnInit {

  constructor(private dataAreaView: DataAreaViewManagerSercvice) { }
private areaManagers: AreaViewManagerInterface
  ngOnInit() {
    this.dataAreaView.getManagerByArea("1ebe74f9-a213-4c5d-c4d5-08d6f4dc8f01").subscribe((areaManagers: AreaViewManagerInterface) => (this.areaManagers = areaManagers));
  }

}
