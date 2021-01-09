import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StockDetailsFormComponent } from './stock-details-form.component';

describe('StockDetailsFormComponent', () => {
  let component: StockDetailsFormComponent;
  let fixture: ComponentFixture<StockDetailsFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StockDetailsFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(StockDetailsFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
