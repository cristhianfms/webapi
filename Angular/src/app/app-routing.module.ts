import { ManagerDashboardComponent } from './components/manager-dashboard/managerDashboard..component';
import { ReportMoreLoggedComponent } from './components/report-more-logged/report-more-logged.component';
import { UserComponent } from './components/user/user.component';
import { AreasComponent } from './components/areas/areas.component';
import { HomeComponent } from './components/home/home.component';
import { SignInComponent } from './components/sign-in/sign-in.component';
import { LoginComponent } from './components/login/login.component';
import { NgModule, Component } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { IndicatorsComponent } from './components/indicators/indicators.component'
import { ReportsComponent } from './components/reports/reports.component';
import { ConditionComponent } from './components/condition/condition.component';
import { AreaViewindicatorsComponent } from './components/area-viewindicators/area-viewindicators.component';
import { AreaAddindicatorsComponent } from './components/area-addindicators/area-addindicators.component';

const routes: Routes = [
  {path:'login',component: LoginComponent},
  {path:'signIn',component: SignInComponent},
  {path:'navBar',component: NavBarComponent},
  {path:'home',component: HomeComponent},
  {path:'manager',component: ManagerDashboardComponent},
  {path:'indicators',component: IndicatorsComponent},
  {path: 'areas', component: AreasComponent},
  {path: 'user', component:UserComponent},
  {path: 'report-user-more-logged', component:ReportMoreLoggedComponent},
  {path: 'report-indicator-more-hidden', component:ReportsComponent},
  {path: 'condition', component:ConditionComponent},
  { path: 'areaviewindicators/:id', component: AreaViewindicatorsComponent },
  { path: 'areaaddindicators/:id', component: AreaAddindicatorsComponent },
  //AGREGAR COMPONENTES DE SANTIAGO
  //{ path: 'areaviewmanagers/:id', component: AreaViewindicatorsComponent },
  //{ path: 'areaaddmanagers/:id', component: AreaViewindicatorsComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
