import { Injectable } from '@angular/core';
import { Point } from './point';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Observable, retry } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class BoardApiService {
  baseUrl = 'https://localhost:7269/'
  constructor(private http: HttpClient) { }
  async getBoard() : Promise<Point[]> {
    const data = await fetch(`${this.baseUrl}board`);
    console.log(data);
    return (await data.json()) ?? [];
  }
  getNewBoard(): Observable<HttpResponse<Point[]>> {
    return this.http.get<Point[]>(`${this.baseUrl}board`, { observe: 'response'});

  }
  postBoard(cells: Point[]): Observable<Point[]>{
    //point to API to start board
    return this.http.post<Point[]>(`${this.baseUrl}board`, cells);
  }
  getNextStep(): Observable<HttpResponse<Point[]>> {
    console.log('in get next step');
      return this.http.get<Point[]>(`${this.baseUrl}board/next`, { observe: 'response'});
  }
}
