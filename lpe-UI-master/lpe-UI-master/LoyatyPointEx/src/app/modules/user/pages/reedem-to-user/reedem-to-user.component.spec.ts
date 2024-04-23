import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReedemToUserComponent } from './reedem-to-user.component';

describe('ReedemToUserComponent', () => {
  let component: ReedemToUserComponent;
  let fixture: ComponentFixture<ReedemToUserComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ReedemToUserComponent]
    });
    fixture = TestBed.createComponent(ReedemToUserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
