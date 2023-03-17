import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { RaceResponse } from './_transferObjects/Race';

@Injectable({
  providedIn: 'root'
})
export class RaceService {

  baseURL = 'https://localhost:7098/api';

  constructor(private http: HttpClient) { }

  listRaces(): Observable<RaceResponse>{
    return this.http.get<RaceResponse>(`${this.baseURL}/Race/ListRaces`);
  }
}
