import { Injectable } from '@angular/core';
import {HttpClient,HttpHeaders} from '@angular/common/http';
import {Observable} from "rxjs/internal/Observable";
import {AuthorizationService} from './authorization.service';
import {map} from 'rxjs/operators';
import {ReportsInterface} from '../Models/reports-interface';
import {environment} from '../../environments/environment'

@Injectable({
  providedIn: 'root'
})
export class DataReportsService {

  constructor( private http: HttpClient, private authService : AuthorizationService) {
    console.log("el servicio Reports esta activo");
   }
   reports : Observable<any>;
   report: Observable<any>;

    headers: HttpHeaders = new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: this.authService.getToken()
    })

    getIndicatorsMoreHidden(){
      return this.http.get(`${environment.apiUrl}Logs/IndicatorsMoreHidden`,{headers: this.headers})
    }

    getLogsBetweenDate(dateStart, dateEnd){
      return this.http.get(`${environment.apiUrl}/Logs/ActionLogsByDate?date_from=${dateStart}&date_to=${dateEnd}`,{headers: this.headers})
    }
}
