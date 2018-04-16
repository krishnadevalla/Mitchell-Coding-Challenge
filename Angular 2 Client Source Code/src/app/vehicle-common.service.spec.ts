/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { VehicleCommonService } from './vehicle-common.service';

describe('VehicleCommonService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [VehicleCommonService]
    });
  });

  it('should ...', inject([VehicleCommonService], (service: VehicleCommonService) => {
    expect(service).toBeTruthy();
  }));
});
