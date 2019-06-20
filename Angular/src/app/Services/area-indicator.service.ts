import { Injectable } from '@angular/core';
import { Http, Response, RequestOptions, Headers } from "@angular/http";
import { Observable, throwError } from "rxjs"; 
import { map, tap, catchError } from 'rxjs/operators';
import {AreaIndicatorJSON} from '../Models/area-indicators.json'

@Injectable({
  providedIn: 'root'
})

export class AreaIndicatorService {
  private WEB_API_URL : string = 'http://localhost:61830/api/Areas';

  constructor(private _httpService: Http) { }
  
  private handleError(error: Response) {
    console.error(error);
    return throwError(error.json().error|| 'Server error');
  }

  //{{domain}}/api/Managers/{{newUserId}}/Indicators
  AddIndicatorToArea(areaId:string, indicatorToAdd:AreaIndicatorJSON ){
    const myHeaders = new Headers();
    myHeaders.append('Accept', 'application/json');    
    const requestOptions = new RequestOptions({headers: myHeaders});
    const requestURL = `${this.WEB_API_URL}/${areaId}/Indicators`;
    console.log(requestURL);
    console.log(indicatorToAdd);
    this._httpService.post(requestURL, indicatorToAdd, requestOptions).subscribe();
        /*.pipe(
            map((response : Response) => <IndicatorAddInterface> response.json()),
            tap(data => console.log('Los datos que obtuvimos fueron: ' + JSON.stringify(data))),
            catchError(this.handleError)
        );*/
  }
}
