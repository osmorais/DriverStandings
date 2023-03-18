import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Race } from '../_models/Race';
import { RaceService } from '../_services/RaceService'
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-races',
  templateUrl: './races.component.html',
  styleUrls: ['./races.component.scss']
})
export class RacesComponent {
  races: Race[];
  fileName: string = '';
  public loading = false;

  constructor(private raceService: RaceService,
              public router: Router,
              private toastr: ToastrService){
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
    this.loading = true;
    this.raceService.listRaces().subscribe({
      next: _response => {
        this.races = _response.items;
        this.loading = false;
        console.log(this.races);
        this.toastr.success(`Corridas retornadas com sucesso!`);
      },
      error: err => {
        // this.toastr.error('Não foi possível recuperar os dados do Cosumo.', 'Verifique sua conexão');
        this.loading = false;
        console.error(err);
        this.toastr.error('Erro ao tentar recuperar as corridas.');
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

        this.loading = true;
        reader.onload = (e: any) => {
            const text = e.target.result;
            console.log(text);

            this.raceService.postRegra(text).subscribe({
              next: _response => {
                // this.races = _response.Item;
                this.races = [];
                this.listRaces();
                this.loading = false;
                this.toastr.success(`Upload da nova corrida feito com sucesso!`);
              },
              error: err => {
                // this.toastr.error('Não foi possível recuperar os dados do Cosumo.', 'Verifique sua conexão');
                this.loading = false;
                console.error(err);
                this.toastr.success(`Erro ao tentar fazer o upload da corrida.`);
              }
            })
        };
    }
  }

}
