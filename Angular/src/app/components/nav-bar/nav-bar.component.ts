import { Component, OnInit } from '@angular/core';
import {AuthorizationService} from '../../services/authorization.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {
  constructor(private authService: AuthorizationService, private location: Location) { }
  public app_name = 'Reports Aplication';
  public isLogged = false;

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
    }
  }
}