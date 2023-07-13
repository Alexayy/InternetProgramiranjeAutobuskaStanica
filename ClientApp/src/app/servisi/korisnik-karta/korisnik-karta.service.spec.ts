import { TestBed } from '@angular/core/testing';

import { KorisnikKartaService } from './korisnik-karta.service';

describe('KorisnikKartaService', () => {
  let service: KorisnikKartaService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(KorisnikKartaService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
