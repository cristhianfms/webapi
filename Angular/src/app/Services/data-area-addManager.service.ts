import { ManagerIdInterface } from './../Models/managerId-interafce';
import { Injectable } from '@angular/core';
import {HttpClient,HttpHeaders} from '@angular/common/http';
import {Observable} from "rxjs/internal/Observable";
import {Users} from '../User'
import { tokenName } from '@angular/compiler';
import {AuthorizationService} from './authorization.service';
import {map} from 'rxjs/operators';
import {UserInterface} from '../Models/user-interface';
import {AreaInterface} from '../Models/area-interface';
import { ConcatSource } from 'webpack-sources';

@Injectable({
  providedIn: 'root'
})
export class DataAreaAddManagerSercvice {

  constructor( private http: HttpClient, private authService : AuthorizationService) {
   }
   public manager: ManagerIdInterface = {
    ManagerId:''
  }
    headers: HttpHeaders = new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: this.authService.getToken()
    })

    addManagerByArea(managerId: string, areaId){
      this.manager.ManagerId =managerId
        return this.http.post(`http://localhost:55846/api/Areas/${areaId}/Managers`,this.manager,{headers: this.headers}).pipe(map(data=>data));
      }
}
