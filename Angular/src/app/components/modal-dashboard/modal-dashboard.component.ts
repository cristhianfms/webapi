import { ManagerService } from '../../services/manager.service';
import { Component, OnInit } from '@angular/core';
import {NgForm} from '@angular/forms';
import {Location} from '@angular/common';

@Component({
  selector: 'app-modal-dashboard',
  templateUrl: './modal-dashboard.component.html',
  styleUrls: ['./modal-dashboard.component.css']
})
export class ModalDashboardComponent implements OnInit {

  constructor(private dataManager: ManagerService, private location: Location) { }

  ngOnInit() {
  }

  onSaveIndicator(dashboardForm: NgForm):void {
    console.log('metodo onSaveIndicator model')
    console.log(dashboardForm.value)
    this.dataManager.updateIndicatorConfig("dd60997e-3764-47d3-b680-665537f2a1ea",dashboardForm.value).subscribe(indicator => location.reload());
}
}
