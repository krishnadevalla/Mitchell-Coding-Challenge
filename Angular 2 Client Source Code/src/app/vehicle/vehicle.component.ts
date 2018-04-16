import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { IVehicle } from '../ivehicle';
import { VehiclesService } from '../vehicles.service';
import { VehicleCommonService } from '../vehicle-common.service';
import { Vehicle } from '../vehicle';

@Component({
  selector: 'app-vehicle',
  templateUrl: './vehicle.component.html',
  styleUrls: ['./vehicle.component.css']
})
export class VehicleComponent implements OnInit{
  selectedVehicle:IVehicle;

  @Input() vehicle:IVehicle;
  @Output() delete = new EventEmitter();

  constructor(private service:VehiclesService, private common:VehicleCommonService){}

  clickedVehicle(clickvehicle:IVehicle)
  {
    document.getElementById(clickvehicle.Id.toString()).style.setProperty("background-color","yellowgreen");
    document.getElementById(clickvehicle.Id.toString()).style.setProperty("color","white");
    this.common.changeVehicle(clickvehicle);
  }
  deleteVehicle(deleteId:number)
  {
    this.service.deleteVehicle(deleteId).subscribe(
      result => 
      {
              this.delete.emit();
              this.common.changeVehicle(new Vehicle());
      },       
      error => alert(error));

  }
  ngOnInit()
  {
    this.common.currentVehicle.subscribe(v=>this.selectedVehicle=v);
  }
}
