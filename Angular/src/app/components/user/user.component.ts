import { UserInterface } from './../../Models/user-interface';
import { DataService } from './../../services/data.service';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  constructor(private dataUser: DataService) { 
  }

  private users:UserInterface;

  ngOnInit() {
    this.dataUser.getAllUsers().subscribe((users: UserInterface) => (this.users = users));

  }
  onDeleteUser(id:string): void {
    console.log('entro al onDeleteUser')
    console.log(id)
    if(confirm('Are you sure to delete?')){
      this.dataUser.DeleteUser(id).subscribe();
    }
  }
  onPreUpdateUser(user: UserInterface): void {
    this.dataUser.selectedUser = Object.assign({},user);
  }
  
  resetForm(userForm?:NgForm): void {
    this.dataUser.selectedUser = {
      Id:null,
      Name:'',
      UserName:'',
      LastName:'',
      Role:'',
      Mail:''
    };
  }
}
