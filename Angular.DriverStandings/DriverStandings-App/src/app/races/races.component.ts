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
  fileName: string = '';

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

  onFileSelected(event: any) {

    const file:File = event.target.files[0];

    if (file) {
        this.fileName = file.name;
        const formData = new FormData();
        formData.append("thumbnail", file);

        const reader = new FileReader();

        reader.readAsText(file);

        reader.onload = (e: any) => {
            const text = e.target.result;
            console.log(text);

            this.raceService.postRegra(text).subscribe({
              next: _response => {
                // this.races = _response.Item;
              },
              error: err => {
                // this.toastr.error('Não foi possível recuperar os dados do Cosumo.', 'Verifique sua conexão');
                console.error(err);
              }
            })
        };
    }
  }

}
