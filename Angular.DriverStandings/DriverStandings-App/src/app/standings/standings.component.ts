import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
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
  public loading = false;

  constructor(public router: Router,
              private route: ActivatedRoute,
              private raceService: RaceService,
              private toastr: ToastrService){
    this.raceId = 0;
    this.race = new Race();
    this.route.params.subscribe(params => this.raceId = params['id']);
  }


  ngOnInit() : void{
    this.getRace();
  }

  getRace() : void{
    this.loading = true;
    this.raceService.getRace(this.raceId).subscribe({
      next: _response => {
        this.loading = false;
        if(_response.success){
          this.race = _response.item;
          this.toastr.success(`classificações recuperadas!\n` , _response.message);
        }
        else{
          this.toastr.error('Erro ao tentar recuperar as classificações.\n' , _response.message);
        }
      },
      error: err => {
        // this.toastr.error('Não foi possível recuperar os dados do Cosumo.', 'Verifique sua conexão');
        this.loading = false;
        console.error(err);
        this.toastr.error('Erro ao tentar recuperar as classificações.\n' , err.message);
      }
    })
  }

  returnHours(date: Date): string{
    return new Date(date).toLocaleTimeString([], {hour: '2-digit', minute:'2-digit', second:'2-digit'});
  }
}
