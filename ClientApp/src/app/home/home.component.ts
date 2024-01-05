import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { linija } from '../../models/linija';
import { LinijaService } from '../servisi/linija/linija.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  public linije: linija[] = [];
  public isPretraga: boolean = false;
  public porukaNemaRezultata: string | undefined;

  constructor(private linijaService: LinijaService) { }

  ngOnInit(): void {
    this.linijaService.getLinije().subscribe(data => {
      this.linije = data;
    });
  }

  public pretraziLinije(form: NgForm): void {
    if (form.valid) {
      this.linijaService.pretraziLinije(form.value.polazna, form.value.dolazna).subscribe(data => {
        this.linije = data;
        this.isPretraga = true;
        if (data.length === 0) {
          // Dodajte poruku da nema rezultata
          this.porukaNemaRezultata = "Ne postoji";
        }
      });
    }
  }

  public resetujPretragu(): void {
    this.linijaService.getLinije().subscribe(data => {
      this.linije = data;
      this.isPretraga = false;
    });
  }
}
