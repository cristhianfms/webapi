import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';

import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { ManagerDashboardComponent } from './manager-dashboard/managerDashboard..component';
import { ManagerService } from './Services/Manager.service';
import { SortIndicatorDetailsPipe } from './manager-dashboard/sort-indicator-details.pipe';
import { VisibleIndicatorDetailsPipe } from './manager-dashboard/visible-indicator-details.pipe';
import { WelcomeComponent } from './welcome/welcome.component';
import { IndicatorDetail } from './Models/IndicatorDetail';
import { ManagerConfigurationComponent } from './manager-configuration/manager-configuration.component';


@NgModule({
  declarations: [
    AppComponent,
    ManagerDashboardComponent,
    SortIndicatorDetailsPipe,
    VisibleIndicatorDetailsPipe,
    WelcomeComponent,
    ManagerConfigurationComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    RouterModule.forRoot([
      { path: 'managerDashboard', component: ManagerDashboardComponent },
      {path: 'managerConfiguration', component:ManagerConfigurationComponent},
      //{ path: 'homeworks/:id', component: HomeworksListComponent }, // esto sería otro componente! por ejemplo uno que muestre el detalle de las tareas
      { path: 'welcome', component:  WelcomeComponent }, 
      { path: '', redirectTo: 'welcome', pathMatch: 'full' }, // configuramos la URL por defecto
      { path: '**', redirectTo: 'welcome', pathMatch: 'full'} //cualquier otra ruta que no matchee, va a ir al WelcomeComponent, aca podría ir una pagina de error tipo 404 Not Found
  ])
  ],
  providers: [ManagerService],
  bootstrap: [AppComponent]
})
export class AppModule { }
