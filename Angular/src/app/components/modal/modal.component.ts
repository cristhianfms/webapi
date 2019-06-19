import { Component, OnInit } from '@angular/core';
import {DataAreaService} from '../../services/dataArea.service';
import {NgForm} from '@angular/forms';
import {Location} from '@angular/common';


@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.css']
})
export class ModalComponent implements OnInit {

  constructor(private dataArea: DataAreaService, private location: Location) { }

  ngOnInit() {
  }

  onSaveArea(areaForm: NgForm):void {
    console.log('metodo onSaveArea model')
    console.log(areaForm.value)
    if(areaForm.value.Id == null){
      console.log('entro al post')
      this.dataArea.CreateArea(areaForm.value).subscribe(area => location.reload());
    }
    else {
      this.dataArea.ModifyArea(areaForm.value).subscribe(area => location.reload());
    }
}

}
