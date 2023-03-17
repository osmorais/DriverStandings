export class Lap{
  constructor(lapId: number, lapNumber: number, lapTime: Date, averageSpeed: number){
    this.lapId = lapId;
    this.lapNumber = lapNumber;
    this.lapTime = lapTime;
    this.averageSpeed = averageSpeed;
  }

  lapId: number;
  lapNumber: number;
  lapTime: Date;
  averageSpeed: number;
}
