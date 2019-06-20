//import { UserInterface } from 'src/app/models/user-interface';
//import { UserInterface } from './../components/Models/user-interface';
//import { AuthService } from 'src/app/services/auth.service';
import { Injectable } from '@angular/core';
import {HttpClient,HttpHeaders} from '@angular/common/http';
import {Observable} from "rxjs/internal/Observable";
import {AuthorizationService} from './authorization.service';
import {map} from 'rxjs/operators';
import {AreaInterface} from '../Models/area-interface';
import {IndicatorAddInterface} from '../Models/indicator-add-interface';

@Injectable({
  providedIn: 'root'
})
export class DataAreaService {

  constructor( private http: HttpClient, private authService : AuthorizationService) {
    console.log("el servicio Area esta activo");
   }
   areas : Observable<any>;
   area: Observable<any>;
   
   public selectedArea: AreaInterface ={
     Id:null,
     Name:'',
     ConnectionString:''
   };

    headers: HttpHeaders = new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: this.authService.getToken()
    })

    getAllAreas(){
      return this.http.get('http://localhost:61830/api/Areas',{headers: this.headers})
    }
  
    getAreaById(id: string){
      return this.http.get(`http://localhost:61830/api/Areas/${id}`,{headers: this.headers})
    }

    ModifyArea(area :AreaInterface){
      return this.http.put<AreaInterface>(`http://localhost:61830/api/Areas/${area.Id}`,area ,{headers: this.headers}).pipe(map(data=>data))
    }
  
    DeleteArea(id: string){
      return this.http.delete<AreaInterface>(`http://localhost:61830/api/Areas/${id}`, {headers: this.headers})
    }

    CreateArea(area: AreaInterface){
      console.log('el area es: '+ area)
      return this.http.post<AreaInterface>('http://localhost:61830/api/Areas',area, {headers: this.headers}).pipe(map(data=>data))
    }


    getAllAreaIndicators(id:string){
      return this.http.get(`http://localhost:61830/api/Areas/${id}/Indicators`,{headers: this.headers})
    }

    //POST {{domain}}/api/Areas/{{areaId}}/Indicators
    //AddIndicatorToArea(areaid:string, indicator:IndicatorAddInterface){
      //this.http.post(`http://localhost:61830/api/Areas/1817ec80-cf1c-46d6-8e04-08d6f35d67ba/Indicators`,indicator, {headers: this.headers}).pipe(map(data=>data))
      //return this.http.get(`http://localhost:61830/api/Areas/${areaid}`,{headers: this.headers})
      //this.http.post(`http://localhost:61830/api/Areas/${areaid}/Indicators`,indicator, {headers: this.headers}).pipe(map(data=>data));
     // console.log("termino la llamada")
   //}
   
}
