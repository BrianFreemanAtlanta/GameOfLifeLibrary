import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CellEntryComponent } from './cell-entry.component';

describe('CellEntryComponent', () => {
  let component: CellEntryComponent;
  let fixture: ComponentFixture<CellEntryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CellEntryComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CellEntryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
