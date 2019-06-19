import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ReportMoreLoggedComponent } from './report-more-logged.component';

describe('ReportMoreLoggedComponent', () => {
  let component: ReportMoreLoggedComponent;
  let fixture: ComponentFixture<ReportMoreLoggedComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ReportMoreLoggedComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ReportMoreLoggedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
