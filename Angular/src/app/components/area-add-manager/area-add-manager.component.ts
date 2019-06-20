import { ManagerIdInterface } from './../../Models/managerId-interafce';
import { DataService } from './../../services/data.service';
import { UserInterface } from 'src/app/models/user-interface';
import { DataAreaAddManagerSercvice } from './../../services/data-area-addManager.service';
import { DataAreaViewManagerSercvice } from './../../services/data-areaViewManager.service';
import { Component, OnInit } from '@angular/core';
import { AreaViewManagerInterface } from './../../Models/area-viewManager-interface';
import { ActivatedRoute } from '@angular/router';
import { OnlyManagersPipe } from './only-managers.pipe';

@Component({
  selector: 'app-area-add-manager',
  templateUrl: './area-add-manager.component.html',
  styleUrls: ['./area-add-manager.component.css']
})
export class AreaAddManagerComponent implements OnInit {

  areaId: string;
  private sub: any;
  private users:UserInterface;
  

  constructor(private route: ActivatedRoute,private dataUser: DataService,
    private dataAreaAdd: DataAreaAddManagerSercvice) { }

  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      this.areaId = params['id']; 
   });
    this.dataUser.getAllUsers().subscribe((users: UserInterface) => (this.users = users));
  }
  
  ngOnDestroy() {
    this.sub.unsubscribe();
  }

  addAreaManager(managerId: string){
    this.dataAreaAdd.addManagerByArea(managerId,this.areaId).subscribe();
  }

}
