import { Component, HostListener, Input } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, FormsModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Conways Game Of Life';
  cells: Array<point> = [
    {x: 0,
      y: 0
    },
    {x: 1,
      y: 0
    },
    {x: 2,
      y: 0
    },
    {x: 1,
      y: -1
    },
    {x: 1,
      y: 1
    },
    {x: 100, y: 0}
  ];
  boardHeight = 500;
  boardWidth = 1000;
  public zoomFactor: number = 4;
  public getScreenWidth: number = 0;
  public getScreenHeight: number = 0;
  ngOnInit() {
    this.getScreenWidth = window.innerWidth;
    this.getScreenHeight = window.innerHeight;
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
  getCanvasPoint(p: point){
    let xCenter = this.boardWidth/2;
    let xOffset = xCenter/this.zoomFactor;
    let yCenter = this.boardHeight/2;
    let yOffset = yCenter/this.zoomFactor;
    let newX = p.x + xOffset;
    let newY = p.y + yOffset;
    let drawX = newX * this.zoomFactor;
    let drawY = newY * this.zoomFactor;
    let fullX = (p.x + this.boardWidth/2/this.zoomFactor) * this.zoomFactor
    return {
        x: p.x * this.zoomFactor + (this.boardWidth/2), 
        y: p.y * this.zoomFactor + (this.boardHeight/2)
      }
  }
}
export type point  = {
  x: number,
  y: number
} 