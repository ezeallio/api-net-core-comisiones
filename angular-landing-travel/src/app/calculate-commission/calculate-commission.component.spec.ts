import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CalculateCommissionComponent } from './calculate-commission.component';

describe('CalculateCommissionComponent', () => {
  let component: CalculateCommissionComponent;
  let fixture: ComponentFixture<CalculateCommissionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CalculateCommissionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CalculateCommissionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
