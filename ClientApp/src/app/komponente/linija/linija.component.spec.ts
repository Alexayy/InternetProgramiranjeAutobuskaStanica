import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LinijaComponent } from './linija.component';

describe('LinijaComponent', () => {
  let component: LinijaComponent;
  let fixture: ComponentFixture<LinijaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LinijaComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LinijaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
