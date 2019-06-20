import { ManagerIdInterface } from './../../Models/managerId-interafce';
import { DataService } from './../../services/data.service';
import { UserInterface } from 'src/app/models/user-interface';
import { DataAreaAddManagerSercvice } from './../../services/data-area-addManager.service';
import { DataAreaViewManagerSercvice } from './../../services/data-areaViewManager.service';
import { Component, OnInit } from '@angular/core';
import { AreaViewManagerInterface } from './../../Models/area-viewManager-interface';


@Component({
  selector: 'app-area-add-manager',
  templateUrl: './area-add-manager.component.html',
  styleUrls: ['./area-add-manager.component.css']
})
export class AreaAddManagerComponent implements OnInit {

  constructor(private dataUser: DataService,private dataAreaAdd: DataAreaAddManagerSercvice) { }

  private users:UserInterface;


  ngOnInit() {
    this.dataUser.getAllUsers().subscribe((users: UserInterface) => (this.users = users));
  }

  addAreaManager(managerId: string){
    this.dataAreaAdd.addManagerByArea(managerId,"1ebe74f9-a213-4c5d-c4d5-08d6f4dc8f01").subscribe();
  }

}
