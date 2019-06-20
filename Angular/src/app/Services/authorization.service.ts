import { Injectable } from '@angular/core';
import {HttpClient,HttpHeaders} from '@angular/common/http';
import {Observable} from "rxjs/internal/Observable";
import { last } from 'rxjs/operators';
import {map} from 'rxjs/operators';
import { isNullOrUndefined } from 'util';
import {UserInterface} from '../Models/user-interface';
 

@Injectable({
  providedIn: 'root'
})
export class AuthorizationService {

  constructor( private http: HttpClient) { }

   httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json'//,
      //'Authorization' : this.getToken()
    })
  };

  createrUser(name: string, lastName: string, userName: string, email: string, password:string){
    console.log(name)
    console.log(lastName)
    console.log(userName)
    console.log(email )
    console.log(password)
  
    return this.http.post<UserInterface>('http://localhost:55846/api/Users',
    {
      name: name, 
      lastName: lastName,
      userName: userName,
      email: email,
      password: password
     },this.httpOptions).pipe(map(data=>data));
  }

  loginUser(userName: string, password: string):Observable<any>{
    console.log(userName)
    console.log(password)
    return this.http.post<UserInterface>('http://localhost:55846/api/Token',{userName: userName, password: password},this.httpOptions).pipe(map(data => data));  
  }

  setUser(user:UserInterface): void{
    let user_string = JSON.stringify(user);
    localStorage.setItem('currentUser', user_string)
  }

  setToken(token) : void{
    localStorage.setItem('accessToken',token);
  }
  setUserId(userId) : void{
    localStorage.setItem('userId',userId);
  }
  setRole(role) : void{
    localStorage.setItem('role',role);
  }


  getToken(){
    return localStorage.getItem('accessToken');
  }
  getRole(){
    return localStorage.getItem('role');
  }
  getUserId(){
    return localStorage.getItem('userId');
  }

  getCurrentUser(): UserInterface{
    let user_string = localStorage.getItem('currentUser');
    if(!isNullOrUndefined(user_string)){
      let user: UserInterface = JSON.parse(user_string)
      return user;
    }
    else return null;
  }

  logOut(): void{
    localStorage.removeItem('currentUser')
    localStorage.removeItem('accessToken')
  }
}
