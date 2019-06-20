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
export class DataService {

  constructor( private http: HttpClient, private authService : AuthorizationService) {
    console.log("el servicio esta activo");
   }
   users : Observable<any>;
   user: Observable<any>;
   public selectedUser: UserInterface ={
    Id:null,
    Name:'',
    UserName:'',
    LastName:'',
    Role:'',
    Mail:''
  };

    headers: HttpHeaders = new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: this.authService.getToken()
    })

    getAllUsers(){
      return this.http.get(`${environment.apiUrl}/Users`,{headers: this.headers})
    }
  
    getUserById(id: string){
      return this.http.get(`${environment.apiUrl}/Users/${id}`,{headers: this.headers})
    }

    ModifyUser(user :UserInterface){
      console.log("entre al modify con PUT")
      console.log(user)
      return this.http.put<UserInterface>(`${environment.apiUrl}/Users/${user.Id}`,user ,{headers: this.headers}).pipe(map(data=>data));
    }
  
    DeleteUser(id: string){
      return this.http.delete<UserInterface>(`${environment.apiUrl}/Users/${id}`, {headers: this.headers}).pipe(map(data=>data));
    }
    getAllIndicators(){
      return this.http.get(`${environment.apiUrl}/Indicators`,{headers: this.headers})
    }
  
    CreateUser(user :UserInterface){
      console.log('el user es: '+user)
      return this.http.post<UserInterface>(`${environment.apiUrl}/Users/`,user ,{headers: this.headers}).pipe(map(data=>data));
    }
}
