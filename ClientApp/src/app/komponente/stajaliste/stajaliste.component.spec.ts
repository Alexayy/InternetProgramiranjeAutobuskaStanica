import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StajalisteComponent } from './stajaliste.component';

describe('StajalisteComponent', () => {
  let component: StajalisteComponent;
  let fixture: ComponentFixture<StajalisteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StajalisteComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StajalisteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
