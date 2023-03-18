import { Driver } from "./Driver";

export class Race{
  constructor(){
    this.raceId = 0;
    this.numberOfLaps = 0;
    this.drivers = [];
  }

  raceId: number;
  numberOfLaps: number;
  drivers: Driver[]
}
