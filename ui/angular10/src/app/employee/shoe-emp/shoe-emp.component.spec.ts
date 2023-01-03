import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShoeEmpComponent } from './shoe-emp.component';

describe('ShoeEmpComponent', () => {
  let component: ShoeEmpComponent;
  let fixture: ComponentFixture<ShoeEmpComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShoeEmpComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShoeEmpComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
