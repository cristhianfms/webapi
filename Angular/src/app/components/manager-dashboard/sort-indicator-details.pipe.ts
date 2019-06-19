import { Pipe, PipeTransform } from '@angular/core';
import {IndicatorDetail} from '../../Models/IndicatorDetail'

@Pipe({
  name: 'sortIndicatorDetails'
})
export class SortIndicatorDetailsPipe implements PipeTransform {

  transform(list: Array<IndicatorDetail>, args?: any): Array<IndicatorDetail> {
    if(!list) return [];
    return list.sort( (a:IndicatorDetail,b:IndicatorDetail) =>
      a.position > b.position ? 1 : -1
    );
  }

}
