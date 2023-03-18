import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Race } from '../_models/Race';
import { RaceService } from '../_services/RaceService'

@Component({
  selector: 'app-races',
  templateUrl: './races.component.html',
  styleUrls: ['./races.component.scss']
})
export class RacesComponent {
  races: Race[];

  constructor(private raceService: RaceService,
              public router: Router){
    this.races = [];
  }

  ngOnInit(): void{
    this.listRaces();
  }

  openPage(raceId: number){
    this.redirectTo('/standings/' + raceId);
  }

  redirectTo(uri: string){
    this.router.navigateByUrl('/#', {skipLocationChange: true}).then(() =>
    this.router.navigate([uri]));
 }

  public listRaces() : void{
    this.raceService.listRaces().subscribe({
      next: _response => {
        this.races = _response.items;
        console.log(this.races);
      },
      error: err => {
        // this.toastr.error('Não foi possível recuperar os dados do Cosumo.', 'Verifique sua conexão');
        console.error(err);
      }
    })
  }

}
