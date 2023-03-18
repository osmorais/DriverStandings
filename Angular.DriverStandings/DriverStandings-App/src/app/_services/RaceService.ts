import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { RaceRequest, RaceResponse, RaceResponseList } from './_transferObjects/Race';

@Injectable({
  providedIn: 'root'
})
export class RaceService {
  baseURL = 'https://localhost:7098/api';

  constructor(private http: HttpClient) { }

  listRaces(): Observable<RaceResponseList>{
    return this.http.get<RaceResponseList>(`${this.baseURL}/Race/ListRaces`);
  }

  postRegra(fileValue: string): Observable<RaceResponse>{
    let raceRequest = new RaceRequest();
    raceRequest.Item = fileValue;
    return this.http.post<RaceResponse>(`${this.baseURL}/Race/UploadRaceByFile`, raceRequest);
  }
}
