import { Component, inject, HostListener } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CellEntryComponent } from '../cell-entry/cell-entry.component';
import { Point } from '../point';
import { BoardApiService } from '../board-api.service';
@Component({
  selector: 'app-board',
  standalone: true,
  imports: [FormsModule, CellEntryComponent],
  templateUrl: './board.component.html',
  styleUrl: './board.component.css'
})
export class BoardComponent {
  title = 'Conways Game Of Life';
  cells: Array<Point> = [];
  gameService: BoardApiService = inject(BoardApiService);
  boardHeight = 500;
  boardWidth = 1000;
  public zoomFactor: number = 4;
  public getScreenWidth: number = 0;
  public getScreenHeight: number = 0;
  constructor() {
    this.gameService.getBoard().then((cells: Point[]) =>
      this.cells = cells
    )
  }
  ngOnInit() {
    this.getScreenWidth = window.innerWidth;
    this.getScreenHeight = window.innerHeight;
    this.boardWidth = this.getScreenWidth;
    this.boardHeight = this.getScreenHeight/2;
  }
  @HostListener('window:resize', ['$event'])
  onWindowResize() {
    this.getScreenWidth = window.innerWidth;
    this.getScreenHeight = window.innerHeight;
  }
  drawBoard(){
    const canvas: any  = document.getElementById("board");
    const ctx = canvas.getContext("2d");
    ctx.clearRect(0,0,this.boardWidth, this.boardHeight);
    this.cells.forEach((p) => {
      let o = this.getCanvasPoint(p);
      console.log('drawing at', o);
      ctx.fillRect(o.x, o.y, this.zoomFactor, this.zoomFactor);
    }
    )
  }
  addCell(){
    this.cells.push({x: 0, y: 0});
  }
  getCanvasPoint(p: Point){
    return {
        x: p.x * this.zoomFactor + (this.boardWidth/2), 
        y: -p.y * this.zoomFactor + (this.boardHeight/2)
      }
  }
}
