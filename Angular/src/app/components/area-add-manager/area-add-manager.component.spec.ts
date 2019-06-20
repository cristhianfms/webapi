import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AreaAddManagerComponent } from './area-add-manager.component';

describe('AreaAddManagerComponent', () => {
  let component: AreaAddManagerComponent;
  let fixture: ComponentFixture<AreaAddManagerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AreaAddManagerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AreaAddManagerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
