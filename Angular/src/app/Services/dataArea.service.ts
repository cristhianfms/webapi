//import { UserInterface } from 'src/app/models/user-interface';
//import { UserInterface } from './../components/Models/user-interface';
//import { AuthService } from 'src/app/services/auth.service';
import { Injectable } from '@angular/core';
import {HttpClient,HttpHeaders} from '@angular/common/http';
import {Observable} from "rxjs/internal/Observable";
import {AuthorizationService} from './authorization.service';
import {map} from 'rxjs/operators';
import {AreaInterface} from '../Models/area-interface';

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
      return this.http.get('http://localhost:55846/api/Areas',{headers: this.headers})
    }
  
    getAreaById(id: string){
      return this.http.get(`http://localhost:55846/api/Areas/${id}`,{headers: this.headers})
    }

    ModifyArea(area :AreaInterface){
      return this.http.put<AreaInterface>(`http://localhost:55846/api/Areas/${area.Id}`,area ,{headers: this.headers}).pipe(map(data=>data));
    }
  
    DeleteArea(id: string){
      return this.http.delete<AreaInterface>(`http://localhost:55846/api/Areas/${id}`, {headers: this.headers})
    }

    CreateArea(area: AreaInterface){
      console.log('el area es: '+ area)
      return this.http.post<AreaInterface>('http://localhost:55846/api/Areas',area, {headers: this.headers}).pipe(map(data=>data));
    }

  
}
