import { ManagerConfigurationComponent } from './components/manager-configuration/manager-configuration.component';
import { VisibleIndicatorDetailsPipe } from './components/manager-dashboard/visible-indicator-details.pipe';
import { SortIndicatorDetailsPipe } from './components/manager-dashboard/sort-indicator-details.pipe';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http'
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PruebaComponent } from './components/prueba/prueba.component';
import {DataService} from './services/data.service';
import { LoginComponent } from './components/login/login.component';
import { SignInComponent } from './components/sign-in/sign-in.component';
import { HomeComponent } from './components/home/home.component';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { FormsModule } from '@angular/forms';
import { IndicatorsComponent } from './components/indicators/indicators.component';
import { AreasComponent } from './components/areas/areas.component';
import { ModalComponent } from './components/modal/modal.component';
import { UserComponent } from './components/user/user.component';
import { ModalUserComponent } from './components/modal-user/modal-user.component';
import { ReportsComponent } from './components/reports/reports.component';
import { ReportMoreLoggedComponent } from './components/report-more-logged/report-more-logged.component'
import { ManagerDashboardComponent } from './components/manager-dashboard/managerDashboard..component';
import { ManagerService } from './services/Manager.service';
import {HttpModule} from '@angular/http'

@NgModule({
  declarations: [
    AppComponent,
    PruebaComponent,
    LoginComponent,
    SignInComponent,
    HomeComponent,
    NavBarComponent,
    IndicatorsComponent,
    AreasComponent,
    ModalComponent,
    UserComponent,
    ModalUserComponent,
    ReportsComponent,
    ReportMoreLoggedComponent,
    ManagerDashboardComponent,
    SortIndicatorDetailsPipe,
    VisibleIndicatorDetailsPipe,
    ManagerConfigurationComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    HttpModule,
    FormsModule
  ],
  providers: [DataService,ManagerService],
  bootstrap: [AppComponent]
})
export class AppModule { }
