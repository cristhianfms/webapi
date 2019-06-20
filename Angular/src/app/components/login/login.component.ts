import { UserInterface } from './../../Models/user-interface';
import { AuthorizationService } from './../../services/authorization.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private authService: AuthorizationService, private router: Router) { }
  private user : UserInterface = {
    UserName:"",
    Password:"",
  };
  
  ngOnInit() {
  }
  onLogin(){
    return this.authService.loginUser(this.user.UserName, this.user.Password).subscribe(data => {
      let token = data.token;
      this.authService.setUser(data);
      this.authService.setToken(data.token);
      this.authService.setRole(data.admin);
      this.authService.setUserId(data.id);
      this.router.navigate(["/home"])
      //location.reload();
    });
  }

}

