import { Component, EventEmitter, Input, Output, model } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Point } from '../point';
@Component({
  selector: 'app-cell-entry',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './cell-entry.component.html',
  styleUrl: './cell-entry.component.css',
})
export class CellEntryComponent {
  point = model<Point>({x:0, y: 0});
  @Input() index: number = 0;
  @Input() x: number = 0;
  @Output() xChange = new EventEmitter<number>();
  @Input() y: number = 0;
  @Output() yChange = new EventEmitter<number>();
//@Input() point: Point = {x: 0, y: 0};
//@Output() pointChange = new EventEmitter<Point>();
}
