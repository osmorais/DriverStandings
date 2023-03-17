import { Driver } from "./Driver";

export class Race{
  constructor(raceId: number, numberOfLaps: number, drivers: Driver[]){
    this.raceId = raceId;
    this.numberOfLaps = numberOfLaps;
    this.drivers = drivers;
  }

  raceId: number;
  numberOfLaps: number;
  drivers: Driver[]
}
