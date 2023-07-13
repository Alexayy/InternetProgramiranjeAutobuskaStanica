import { TestBed } from '@angular/core/testing';

import { StajalisteService } from './stajaliste.service';

describe('StajalisteService', () => {
  let service: StajalisteService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(StajalisteService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
