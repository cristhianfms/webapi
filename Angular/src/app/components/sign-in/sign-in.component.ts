import { Router } from '@angular/router';
import { UserInterface } from 'src/app/models/user-interface';
import { AuthorizationService } from './../../services/authorization.service';
import { Component, OnInit } from '@angular/core';
import { Route } from '@angular/compiler/src/core';


@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {

  constructor(private authService: AuthorizationService, private router: Router) { }
  private user: UserInterface = {
    Name:"",
    LastName:"",
    UserName:"",
    Mail:"",
    Role:"",
    Password:""
  }

  ngOnInit() {
  }

  onRegister():void{
    this.authService.createrUser(
      this.user.Name, 
      this.user.LastName, 
      this.user.UserName,
      this.user.Mail,
      this.user.Password
      ).subscribe(user=>{
        console.log(user);
        this.authService.loginUser(this.user.UserName, this.user.Password).subscribe(data=> {
          let token = data;
          this.authService.setToken(token);
          this.authService.setRole(data.admin);
          this.authService.setUserId(data.id);
        });
        this.authService.setUser(user);
        this.router.navigate(['/home']);
      })
  }
}
