import { Injectable } from '@angular/core';
import {HttpClient,HttpHeaders} from '@angular/common/http';
import {Observable} from "rxjs/internal/Observable";
import {AuthorizationService} from './authorization.service';

@Injectable({
  providedIn: 'root'
})
export class DataReportsMoreLoggedService {

  constructor( private http: HttpClient, private authService : AuthorizationService) {
    console.log("el servicio Reports esta activo");
   }
   reports : Observable<any>;
   report: Observable<any>;


    headers: HttpHeaders = new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: this.authService.getToken()
    })

    getReportsMoreLogged(){
      return this.http.get('http://localhost:61830/api/Logs/ManagersMoreLogged',{headers: this.headers})
    }
}
