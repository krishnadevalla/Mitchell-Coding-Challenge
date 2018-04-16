import { Component, OnInit , Output, EventEmitter, Input } from '@angular/core';
import { VehiclesService } from '../vehicles.service';
import { IVehicle } from '../ivehicle';
import { AppComponent } from '../app.component'
import { VehicleCommonService } from '../vehicle-common.service';

@Component({
  selector: 'vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit {
  @Output() message = new EventEmitter<IVehicle[]>();
  @Input() vehicle:IVehicle; 
  
  constructor(private service:VehiclesService,private common:VehicleCommonService){}

  submitModel() {
    if(this.vehicle != undefined)
    {
      if(this.vehicle.Make == null || this.vehicle.Model == null || this.vehicle.Year<1950 || this.vehicle.Year >2050)
      {
        alert("Invalid data");
        return;
      }
      this.service.postVehicle(this.vehicle)
        .subscribe( res => 
                    {
                      this.clearVehicle();
                      this.service.getVehicles().subscribe(data=>
                                      {
                                            this.message.emit(data);
                                      });
                    },
                    error => alert(error)
                  );
    }
  }
  updateModel()
  {
    if(this.vehicle.Make == null || this.vehicle.Model == null || this.vehicle.Year<1950 || this.vehicle.Year >2050)
    {
      alert("Invalid data");
      return;
    }
    this.service.putVehicle(this.vehicle)
      .subscribe( res => 
      {
        this.clearVehicle();
        this.service.getVehicles().subscribe(data=>
        {
              this.message.emit(data);
        });
      },
      error => alert(error)
    );
  }
  clearVehicle()
  {
    this.vehicle.Id = null;
    this.vehicle.Make = null;
    this.vehicle.Model = null;
    this.vehicle.Year = null;
  }
  ngOnInit() {
    this.common.currentVehicle.subscribe(v=>this.vehicle=v);
  }
}