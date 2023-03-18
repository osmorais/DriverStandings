import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Race } from '../_models/Race';
import { RaceService } from '../_services/RaceService';

@Component({
  selector: 'app-standings',
  templateUrl: './standings.component.html',
  styleUrls: ['./standings.component.scss']
})
export class StandingsComponent {
  raceId: number;
  race: Race;

  constructor(public router: Router,
              private route: ActivatedRoute,
              private raceService: RaceService){
    this.raceId = 0;
    this.race = new Race();
    this.route.params.subscribe(params => this.raceId = params['id']);
  }


  ngOnInit() : void{
    this.getRace();
  }

  getRace() : void{
    this.raceService.getRace(this.raceId).subscribe({
      next: _response => {
        this.race = _response.item;
        console.log(this.race);
      },
      error: err => {
        // this.toastr.error('Não foi possível recuperar os dados do Cosumo.', 'Verifique sua conexão');
        console.error(err);
      }
    })
  }

  returnHours(date: Date): string{
    return new Date(date).toLocaleTimeString([], {hour: '2-digit', minute:'2-digit', second:'2-digit'});
  }
}
