import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Rx';
import { IVehicle } from './ivehicle';

@Injectable()
export class VehiclesService {
  constructor(private http: Http) { }
  private vehiclesUrl = 'http://mitchellwebapi.azurewebsites.net/vehicles/'; 

  getVehicles(): Observable<IVehicle[]>
  {
    // ...Get request
    return this.http.get(this.vehiclesUrl)
                    .map((res:Response) => <IVehicle> res.json())
                    .catch((error:any) => Observable.throw(error.json().error || 'Server error'));
  }

  getVehiclesByFilter(filter: string, value: string): Observable<IVehicle[]>
  {
    // ...Get with filter
    if(filter == "" || value == "")
      return this.getVehicles();
    return this.http.get(this.vehiclesUrl+filter+"/"+value)
                    .map((res:Response) => <IVehicle> res.json())
                    .catch((error:any) => Observable.throw(error.json().error || 'Server error'));
  }

  postVehicle(vehicle:IVehicle):Observable<Response>
  {
    let headers = new Headers({ 'Content-Type': 'application/json' });
    let options = new RequestOptions({ headers: headers });
    let body = JSON.stringify(vehicle);
    // ...Post request
    return this.http.post(this.vehiclesUrl, body, options);
  }

  putVehicle(vehicle: IVehicle): Observable<Response>
  {
    let headers = new Headers({ 'Content-Type': 'application/json' });
    let options = new RequestOptions({ headers: headers });
    let body = JSON.stringify(vehicle);
    // ...Post request
    return this.http.put(this.vehiclesUrl, body, options);
  }

  deleteVehicle(id:number):Observable<Response>
  {
    return this.http.delete(this.vehiclesUrl+id)
                    .map(success => success.status)
                    .catch((error:any) => Observable.throw(error.json().error || 'Server error'));
  }
}
