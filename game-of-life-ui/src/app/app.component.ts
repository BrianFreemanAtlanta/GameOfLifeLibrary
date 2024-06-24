import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Conways Game Of Life';
  drawBoard(){
    const canvas: any  = document.getElementById("board");
    const ctx = canvas.getContext("2d");
    ctx.fillRect(0, 0, 150, 75);
    ctx.fillRect(200,10,2,2);
    ctx.fillRect(202,10,2,2);
    ctx.fillRect(204,10,2,2);
  }
}
