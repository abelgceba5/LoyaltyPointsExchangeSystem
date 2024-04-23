import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReedemToBankComponent } from './reedem-to-bank.component';

describe('ReedemToBankComponent', () => {
  let component: ReedemToBankComponent;
  let fixture: ComponentFixture<ReedemToBankComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ReedemToBankComponent]
    });
    fixture = TestBed.createComponent(ReedemToBankComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
