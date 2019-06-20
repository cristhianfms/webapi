import { ManagerService } from '../../services/manager.service';
import { Component, OnInit } from '@angular/core';
import {NgForm} from '@angular/forms';
import {Location} from '@angular/common';
import { AuthorizationService } from 'src/app/services/authorization.service';

@Component({
  selector: 'app-modal-dashboard',
  templateUrl: './modal-dashboard.component.html',
  styleUrls: ['./modal-dashboard.component.css']
})
export class ModalDashboardComponent implements OnInit {

  constructor(private dataManager: ManagerService, private location: Location, 
    private authservice:AuthorizationService) { }

  ngOnInit() {
  }

  onSaveIndicator(dashboardForm: NgForm):void {
    this.dataManager.updateIndicatorConfig(this.authservice.getUserId(),dashboardForm.value).subscribe(indicator => location.reload());
}
}
