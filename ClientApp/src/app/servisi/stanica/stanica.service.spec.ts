import { TestBed } from '@angular/core/testing';

import { StanicaService } from './stanica.service';

describe('StanicaService', () => {
  let service: StanicaService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(StanicaService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
