import { Component, OnInit } from '@angular/core';
import { karta } from '../../../models/karta';
import { KartaService } from '../../servisi/karta/karta.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-karta',
  templateUrl: './karta.component.html',
  styleUrls: ['./karta.component.css']
})

export class KartaComponent implements OnInit {

  public karte: karta[] = {} as karta[];
  public urediKartu: karta | undefined;
  public obrisiKartu: karta | undefined;

  constructor(private kartaServis: KartaService) { }

  ngOnInit(): void {
    this.getKarta();
  }

  public getKarta(): void {
    this.kartaServis.getKarte().subscribe({
      next: (response) => {
        this.karte = response;
        console.log(this.karte);
      },

      error: (err) => {
        console.log(err.message());
      }
    });
  }

  public onDodajKartu(addForm: NgForm): void {
    document.getElementById("dodaj-kartu-form")?.click();
    this.kartaServis.addKarta(addForm.value).subscribe({
      next: (response) => {
        console.log(response);
        this.getKarta();
        addForm.reset();
      },

      error: (err) => {
        alert(err.message());
        addForm.reset();
      }
    });
  }

  public onUrediKartu(karta: karta): void {
    this.kartaServis.updateKarta(karta).subscribe({
      next: (response) => {
        console.log(response);
        this.getKarta();
      },

      error: (err) => {
        alert(err.message());
      }
    });
  }

  public onObrisiKartu(id: number): void {
    if (id != null) {
      this.kartaServis.deleteKarta(id).subscribe({
        next: (response) => {
          console.log(response);
          this.getKarta();
        },

        error: (err) => {
          console.log(err.message());
        }
      });
    }
  }

  public onOpenModal(mode: string, karta?: karta): void {
    var temp = document.getElementById("main-container");
    const button = document.createElement('button');
    button.type = 'button';
    button.style.display = 'none';
    button.setAttribute('data-bs-toggle', 'modal');

    if (mode === 'add') {
      button.setAttribute('data-bs-target', '#dodajKartuModal');
    }

    if (mode === 'uredi') {
      console.log("Uredi pozvan");

      if (karta) {
        console.log(this.urediKartu);
        this.urediKartu = karta;
      }

      button.setAttribute('data-bs-target', '#urediKartuModal');
    }

    if (mode === 'obrisi') {
      console.log('Obrisi pozvan.');

      if (karta) {
        this.obrisiKartu = karta;
      }

      button.setAttribute('data-bs-target', '#obrisiKartuModal');
    }

    if (temp != null) {
      temp.appendChild(button);
    }

    button.click();
  }
}
