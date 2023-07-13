import { ComponentFixture, TestBed } from '@angular/core/testing';

import { KorisnikKartaComponent } from './korisnik-karta.component';

describe('KorisnikKartaComponent', () => {
  let component: KorisnikKartaComponent;
  let fixture: ComponentFixture<KorisnikKartaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ KorisnikKartaComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(KorisnikKartaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
