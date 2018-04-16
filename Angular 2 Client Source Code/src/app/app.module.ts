import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { VehiclesListComponent } from './vehicles-list/vehicles-list.component';
import { VehicleFormComponent } from './vehicle-form/vehicle-form.component';
import { VehiclesService } from './vehicles.service';
import { VehicleCommonService } from './vehicle-common.service'
import { VehicleComponent } from './vehicle/vehicle.component';

@NgModule({
  declarations: [
    AppComponent,
    VehiclesListComponent,
    VehicleFormComponent,
    VehicleComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule
  ],
  providers: [VehiclesService,VehicleCommonService],
  bootstrap: [AppComponent]
})
export class AppModule { }
