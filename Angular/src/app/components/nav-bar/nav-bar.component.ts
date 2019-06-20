import { UserInterface } from 'src/app/models/user-interface';
import { DataService } from './../../services/data.service';
import { Component, OnInit } from '@angular/core';
import {AuthorizationService} from '../../services/authorization.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {
  constructor(private authService: AuthorizationService, private location: Location,private dataService: DataService) { }
  public app_name = 'Reports Aplication';
  public isLogged = false;
  public isAdmin = false;

  ngOnInit() {
    this.onCheckUser();
  }

  onLogout(): void {
    this.authService.logOut();
    location.reload();
  }

  onCheckUser(): void {
    if (this.authService.getToken() == null) {
      this.isLogged = false;
    } else {
      this.isLogged = true;
      console.log('Role: '+this.authService.getRole())
      this.isAdmin = (this.authService.getRole() == 'true');
      console.log('is admin: '+ this.isAdmin)
    }
  }
}