import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { IndicatorsListComponent } from './indicators-list/indicators-list.component';
import { ManagerService } from './Services/Manager.service';
import { SortIndicatorDetailsPipe } from './indicators-list/sort-indicator-details.pipe';
import { VisibleIndicatorDetailsPipe } from './indicators-list/visible-indicator-details.pipe';


@NgModule({
  declarations: [
    AppComponent,
    IndicatorsListComponent,
    SortIndicatorDetailsPipe,
    VisibleIndicatorDetailsPipe
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpModule
  ],
  providers: [ManagerService],
  bootstrap: [AppComponent]
})
export class AppModule { }
