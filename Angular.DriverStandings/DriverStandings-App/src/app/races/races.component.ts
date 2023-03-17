import { Component } from '@angular/core';

@Component({
  selector: 'app-races',
  templateUrl: './races.component.html',
  styleUrls: ['./races.component.scss']
})
export class RacesComponent {


  constructor(){

  }

  ngOnInit(): void{
    this.listRaces();
  }

  public listRaces() : void{

  }
}
