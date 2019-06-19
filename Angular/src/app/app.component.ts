import { Component } from '@angular/core';
import {DataService} from './services/data.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  users = [];
  constructor(private dataService: DataService){
    this.dataService.getAllUsers().subscribe(data => {
    console.log(data)
    })
    ;
  }
}
