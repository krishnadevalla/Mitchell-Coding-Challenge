import { Component } from '@angular/core';
import { IVehicle } from './ivehicle'
import { version } from 'punycode';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  vehicles: IVehicle[]=[];
  vehicle: IVehicle; 
  recieve($event)
  {
    this.vehicles = $event;
  }
}
