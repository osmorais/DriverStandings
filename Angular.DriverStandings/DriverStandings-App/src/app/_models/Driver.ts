import { Lap } from "./Lap";

export class Driver{
  constructor(driverId: number, driverCode: string, name: string, totalTime: Date, laps: Lap[]){
    this.driverId = driverId;
    this.driverCode = driverCode;
    this.name = name;
    this.totalTime = totalTime;
    this.laps = laps;
  }

  driverId: number;
  driverCode: string;
  name: string;
  totalTime: Date;
  laps: Lap[];
}
