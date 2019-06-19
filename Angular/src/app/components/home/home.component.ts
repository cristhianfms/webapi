import { Component, OnInit } from '@angular/core';
import { UserInterface } from '../../Models/user-interface';
import { AuthorizationService } from '../../services/authorization.service'

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent implements OnInit {
  constructor(private authService: AuthorizationService) { }
  user: UserInterface;

  ngOnInit() {
    this.user = this.authService.getCurrentUser();
    console.log(this.user);
  }
}