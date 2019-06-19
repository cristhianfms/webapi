import { DataService } from './../../services/data.service';
import { Component, OnInit } from '@angular/core';
import {NgForm} from '@angular/forms';
import {Location} from '@angular/common';

@Component({
  selector: 'app-modal-user',
  templateUrl: './modal-user.component.html',
  styleUrls: ['./modal-user.component.css']
})
export class ModalUserComponent implements OnInit {

  constructor(private dataUser: DataService, private location: Location) { }

  ngOnInit() {
  }

  onSaveUser(userForm: NgForm):void {
    if(userForm.value.Id == null){
      this.dataUser.CreateUser(userForm.value).subscribe(area => location.reload());
    }
    else {
      this.dataUser.ModifyUser(userForm.value).subscribe(area => location.reload());
    }
  }
    
}

