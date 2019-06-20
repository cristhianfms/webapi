//import { UserInterface } from 'src/app/models/user-interface';
//import { UserInterface } from './../components/Models/user-interface';
//import { AuthService } from 'src/app/services/auth.service';
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
import {environment} from '../../environments/environment'

@Injectable({
  providedIn: 'root'
})
export class DataAreaViewManagerSercvice {

  constructor( private http: HttpClient, private authService : AuthorizationService) {
   }

    headers: HttpHeaders = new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: this.authService.getToken()
    })

    getManagerByArea(managerId){
      console.log('managreId: ' + managerId)
        return this.http.get(`${environment.apiUrl}/Areas/${managerId}/Managers`,{headers: this.headers})
      }

}
