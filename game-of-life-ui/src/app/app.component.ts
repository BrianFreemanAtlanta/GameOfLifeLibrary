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
    console.log('drawing');
    const canvas: any  = document.getElementById("board");
    console.log(canvas);
    const ctx = canvas.getContext("2d");
    ctx.fillRect(0, 0, 150, 75);
    console.log(ctx);
  }
}
