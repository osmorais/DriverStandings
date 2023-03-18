import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-standings',
  templateUrl: './standings.component.html',
  styleUrls: ['./standings.component.scss']
})
export class StandingsComponent {
  raceId: number;

  constructor(public router: Router,
              private route: ActivatedRoute){
    this.raceId = 0;
    this.route.params.subscribe(params => this.raceId = params['id']);
  }

}
