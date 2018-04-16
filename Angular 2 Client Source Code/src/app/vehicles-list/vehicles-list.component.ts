import { Component, OnInit , Input, EventEmitter , Output } from '@angular/core';
import { VehiclesService } from '../vehicles.service';
import { IVehicle } from '../ivehicle';
import { Observable } from 'rxjs/Rx';
import { filter } from 'rxjs/operator/filter';

@Component({
  selector: 'vehicles-list',
  templateUrl: './vehicles-list.component.html',
  styleUrls: ['./vehicles-list.component.css']
})
export class VehiclesListComponent implements OnInit {
  @Input() vehicles:IVehicle[];
  @Output() selectVehicle = new EventEmitter<IVehicle>();

  filterval:string;
  filterList:string[] = ["Id","Make","Model","Year"];
  constructor(private service:VehiclesService){}

  ngOnInit() {
   this.getListofVehicles();
  }
  getListofVehicles()
  {
    this.service.getVehicles().subscribe(data=>
      {
        this.vehicles=data;
      });
  }
  onSearchChange(value:string)
  {
    this.service.getVehiclesByFilter(this.filterval,value).subscribe(data=>
      {
        this.vehicles=data;
      });
  }
}
