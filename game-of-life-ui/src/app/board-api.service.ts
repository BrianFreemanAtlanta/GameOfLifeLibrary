import { Injectable } from '@angular/core';
import { Point } from './point';
@Injectable({
  providedIn: 'root'
})
export class BoardApiService {
  baseUrl = 'https://localhost:7269/'
  constructor() { }
  async getBoard() : Promise<Point[]> {
    const data = await fetch(`${this.baseUrl}board`);
    console.log(data);
    return (await data.json()) ?? [];

    return [
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
      {x: 100, 
        y: 0}
    ];
  }
  postBoard(cells: Point[]){
    //point to API to start board
  }
  getNextStep(): Point[] {
    return [
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
      {x: 100, 
        y: 0}
    ];
  }
}
