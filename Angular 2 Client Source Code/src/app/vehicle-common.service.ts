import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs/BehaviorSubject'
import { IVehicle } from './ivehicle';
import { version } from 'punycode';
import { Vehicle } from './vehicle';

@Injectable()
export class VehicleCommonService {
  private vehicle = new BehaviorSubject<IVehicle>(new Vehicle());
  currentVehicle = this.vehicle.asObservable();
  constructor() { }

  changeVehicle(vehicle:IVehicle)
  {
    this.vehicle.next(vehicle);
  }
}
