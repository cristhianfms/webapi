import { Pipe, PipeTransform } from '@angular/core';
import {IndicatorDetail} from '../Models/IndicatorDetail'

@Pipe({
  name: 'visibleIndicatorDetails'
})
export class VisibleIndicatorDetailsPipe implements PipeTransform {

  transform(list: Array<IndicatorDetail>, args?: any): Array<IndicatorDetail> {
    if(!list) return [];
    return list.filter( x => x.visible == true)
  }

}
