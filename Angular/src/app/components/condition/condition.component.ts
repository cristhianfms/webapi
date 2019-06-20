import { Component, OnInit, Input } from '@angular/core';
import {FormsModule} from '@angular/forms'

@Component({
  selector: 'condition',
  templateUrl: './condition.component.html',
  styleUrls: ['./condition.component.css']
})
export class ConditionComponent implements OnInit {

   @Input('data') item:Object //objecto json de condicion

  constructor() { 
  }

  ngOnInit() {
    console.log(JSON.stringify(this.item));
  }

}
