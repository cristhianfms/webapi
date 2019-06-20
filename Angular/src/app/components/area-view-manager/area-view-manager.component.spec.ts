import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AreaViewManagerComponent } from './area-view-manager.component';

describe('AreaViewManagerComponent', () => {
  let component: AreaViewManagerComponent;
  let fixture: ComponentFixture<AreaViewManagerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AreaViewManagerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AreaViewManagerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
