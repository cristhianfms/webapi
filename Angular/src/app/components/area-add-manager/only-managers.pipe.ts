import { Pipe, PipeTransform } from '@angular/core';
import { UserInterface } from 'src/app/Models/user-interface';

@Pipe({
  name: 'onlyManagers'
})
export class OnlyManagersPipe implements PipeTransform {

  transform(list: Array<UserInterface>, args?: any): Array<UserInterface> {
    if(!list) return [];
    return list.filter( x => x.Role=="M");
  }

}