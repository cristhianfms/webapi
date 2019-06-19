import { Injectable } from '@angular/core';
import { Http, Response, RequestOptions, Headers } from "@angular/http";
import { Observable, throwError } from "rxjs"; 
import { map, tap, catchError } from 'rxjs/operators';
import { IndicatorDetail } from '../Models/IndicatorDetail';

@Injectable({
  providedIn: 'root'
})

export class ManagerService {
  private WEB_API_URL : string = 'http://localhost:61830/api/Managers';

  constructor(private _httpService: Http) { }

  //GET {{domain}}/api/Managers/{{newUserId}}/Indicators
  getAreasByManager(managerId:string): Observable<Array<IndicatorDetail>> {
    const myHeaders = new Headers();
    myHeaders.append('Accept', 'application/json');    
    const requestOptions = new RequestOptions({headers: myHeaders});
    const requestURL = `${this.WEB_API_URL}/${managerId}/Indicators`;

    return this._httpService.get(requestURL, requestOptions)
        .pipe(
            map((response : Response) => <Array<IndicatorDetail>> response.json()),
            tap(data => console.log('Los datos que obtuvimos fueron: ' + JSON.stringify(data))),
            catchError(this.handleError)
        );
  }

  private handleError(error: Response) {
    console.error(error);
    return throwError(error.json().error|| 'Server error');
  }

}
