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
          this.toastr.success(_response.message , `Corrida excluida!\n`);
        }
        else{
          this.toastr.error(_response.message , 'Erro ao tentar excluir a corrida.\n');
        }
      },
      error: err => {
        this.loading = false;
        console.error(err);
        this.toastr.error(err.message , 'Erro ao tentar excluir a corrida.\n');
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
          this.toastr.success(_response.message , `Corridas Recuperadas!\n`);
        }
        else{
          this.toastr.error(_response.message , 'Erro ao tentar recuperar as corridas.\n');
        }
      },
      error: err => {
        this.loading = false;
        console.error(err);
        this.toastr.error(err.message , 'Erro ao tentar recuperar as corridas.\n');
      }
    })
  }

  onFileSelected(event: any) {

    const file:File = event.target.files[0];
    if(file.type !== 'text/plain'){
      this.toastr.error('O arquivo de upload deve ser um arquivo do formato txt ou csv.' , 'Formato Incorreto');
      this.router.navigate(['/']);
    }
    else if (file) {
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
                  this.toastr.success(_response.message , `Feito Upload da nova corrida!\n`);
                  this.openPage(_response.item.raceId);
                }
                else{
                  this.toastr.error(_response.message , 'Erro ao tentar fazer o upload da corrida.\n');
                  this.router.navigate(['/']);
                }
              },
              error: err => {
                this.loading = false;
                console.error(err);
                this.toastr.error(err.message , `Erro ao tentar fazer o upload da corrida.`);
                this.router.navigate(['/']);
              }
            })
        };
    }
  }
}
