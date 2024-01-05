import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { karta } from '../../../models/karta';
import { KartaService } from '../../servisi/karta/karta.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-karta',
  templateUrl: './karta.component.html',
  styleUrls: ['./karta.component.css']
})

export class KartaComponent implements OnInit {
  @ViewChild('urediModal') urediModal!: ElementRef;

  public karte: karta[] = [];
  public urediKartu: karta = { id: 0, rezervacijaID: 0, datumKupovine: new Date };
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
    console.log("Kakva je forma? " + addForm.value);

    if (addForm.valid) {
      let datumKupovine = new Date(addForm.value.datumKupovine).toISOString();

      let novaKarta = {
        ...addForm.value,
        datumKupovine: datumKupovine,
        karteKorisnika: [] 
      }

      this.kartaServis.addKarta(novaKarta).subscribe({
        next: (response) => {
          console.log("Karta uspesno dodata! " + response);
          this.getKarta();
          addForm.reset();
        },

        error: (err) => {
          console.error("Došlo je do greške prilikom dodavanja karte", err);
        }
      });
    } else {
      console.error("Greška: Forma nije validna.");
    }
  }

  public onUrediKartu(editForm: NgForm): void {
    console.log("Kakva je forma? " + editForm.value);

    if (editForm.valid) {

      let datumKupovine = new Date(editForm.value.datumKupovine).toISOString();

      const uredjenaKarta = {
        ...editForm.value,
        datumKupovine: datumKupovine,
        id: this.urediKartu.id,
        karteKorisnika: [] 
      };

      if (uredjenaKarta && uredjenaKarta.id) {
        this.kartaServis.updateKarta(uredjenaKarta).subscribe({
          next: (response) => {
            console.log("Karta uspesno azurirana! " + response);
            this.getKarta();
          },

          error: (err) => {
            console.error("Došlo je do greške prilikom ažuriranja karte! ", err);
          }
        });
      } else {
        console.error("Greška: Podaci karte nisu kompletni.");
      }
    } else {
      console.error("Greška: Forma nije validna.");
    }
  }

  public onObrisiKartu(id: number): void {
    if (this.obrisiKartu && this.obrisiKartu.id) {
      this.kartaServis.deleteKarta(this.obrisiKartu.id).subscribe({
        next: (response) => {
          console.log(response);
          this.getKarta();
        }, error: (err) => {
          console.log(err.message);
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

      if (karta != null) {
        console.log("THIS IN MODAL OPEN " + this.urediKartu);
        this.urediKartu = { ...karta };
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

  public onCloseModal(): void {
    //this.urediKartu.nativeElement.style.display = 'none';
    //this.urediKartu.nativeElement.classList.remove('show');
  }
}
