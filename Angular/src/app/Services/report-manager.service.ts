import { Injectable } from '@angular/core';
import {HttpClient,HttpHeaders} from '@angular/common/http';
import {Observable} from "rxjs/internal/Observable";
import {AuthorizationService} from './authorization.service';
import {map} from 'rxjs/operators';
import {AreaInterface} from '../Models/area-interface';
import {environment} from '../../environments/environment'

@Injectable({
  providedIn: 'root'
})
export class ReportsManagerService {

  constructor( private http: HttpClient, private authService : AuthorizationService) {
    console.log("el servicio ReportsManager esta activo");
   }
   reports : Observable<any>;
   report: Observable<any>;

    headers: HttpHeaders = new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: this.authService.getToken()
    })

    getReport(managerId){
      return this.http.get(`${environment.apiUrl}/Managers/${managerId}/IndicatorsSummary`,{headers: this.headers})
    }
}