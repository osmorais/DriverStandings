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

  public deleteRace(race: Race) : void{
    this.loading = true;
    this.raceService.deleteRace(race).subscribe({
      next: _response => {
        this.loading = false;

        if(_response.success){
          this.races = [];
          this.listRaces();
          this.toastr.success(`Corrida excluida!\n` , _response.message);
        }
        else{
          this.toastr.error('Erro ao tentar excluir a corrida.\n' , _response.message);
        }
      },
      error: err => {
        this.loading = false;
        console.error(err);
        this.toastr.error('Erro ao tentar excluir a corrida.\n' , err.message);
      }
    })
  }

  public listRaces() : void{
    this.loading = true;
    this.raceService.listRaces().subscribe({
      next: _response => {
        this.loading = false;

        if(_response.success){
          this.races = _response.items;
          this.toastr.success(`Corridas Recuperadas!\n` , _response.message);
        }
        else{
          this.toastr.error('Erro ao tentar recuperar as corridas.\n' , _response.message);
        }
      },
      error: err => {
        this.loading = false;
        console.error(err);
        this.toastr.error('Erro ao tentar recuperar as corridas.\n' , err.message);
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

            this.raceService.uploadFile(text).subscribe({
              next: _response => {
                this.loading = false;
                if(_response.success){
                  this.races = [];
                  this.listRaces();
                  this.toastr.success(`Feito Upload da nova corrida!\n` , _response.message);
                }
                else{
                  this.toastr.error('Erro ao tentar fazer o upload da corrida.\n' , _response.message);
                }
              },
              error: err => {
                this.loading = false;
                console.error(err);
                this.toastr.error(`Erro ao tentar fazer o upload da corrida.` , err.message);
              }
            })
        };
    }
  }

}
