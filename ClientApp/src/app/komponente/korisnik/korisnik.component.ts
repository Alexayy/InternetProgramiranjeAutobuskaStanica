import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { korisnik } from '../../../models/korisnik';
import { KorisnikService } from '../../servisi/korisnik/korisnik.service';
import { NgForm } from '@angular/forms';
import { Modal } from 'bootstrap';

@Component({
  selector: 'app-korisnik',
  templateUrl: './korisnik.component.html',
  styleUrls: ['./korisnik.component.css']
})
export class KorisnikComponent implements OnInit {
  @ViewChild('urediModal') urediModal!: ElementRef;

  public korisnici: korisnik[] = [];
  public urediKorisnika: korisnik = { id: 0, email: '', ime: '', prezime: '', uloga: "korisnik", slikaKorisnika: '' };
  public obrisiKorisnika: korisnik | null = null;

  constructor(private korisnikServis: KorisnikService) { }

  ngOnInit(): void {
    this.getKorisnike();
  }

  public getKorisnike(): void {
    this.korisnikServis.getKorisnici().subscribe({
      next: (response) => {
        this.korisnici = response;
        console.log(this.korisnici);
      }, error: (err) => {
        console.log(err.message());
      }
    });
  }

  public onDodajKorisnika(addForm: NgForm): void {
    if (addForm.valid) {

      let noviKorisnik = { ...addForm.value, korisnikoveKarte: [] }

      console.log(noviKorisnik, noviKorisnik.id);

      this.korisnikServis.addKorisnik(noviKorisnik).subscribe({
        next: (response) => {
          console.log("Korisnik uspešno dodat", response);
          this.getKorisnike(); // Osvežava listu autobusa
          addForm.reset(); // Resetuje formu
        },

        error: (error) => {
          console.error("Došlo je do greške prilikom dodavanja korisnika", error);
        }
      });
    } else {
      console.error("Greška: Forma nije validna.");
    }
  }

  public onUrediKorisnika(editForm: NgForm): void {
    // Proveravamo da li forma ima validne podatke
    console.log("Kakva je forma? " + editForm.value);

    if (editForm.valid) {
      const updatedKorisnik = { id: this.urediKorisnika.id, ...editForm.value, korisnikoveKarte: [] };

      if (updatedKorisnik && updatedKorisnik.id) {
        this.korisnikServis.updateKorisnik(updatedKorisnik).subscribe({
          next: (response) => {
            console.log("Korisnik uspešno ažuriran", response);
            this.getKorisnike();
          },
          error: (err) => {
            console.error("Došlo je do greške prilikom ažuriranja korisnika", err);
          }
        });
      } else {
        console.error("Greška: Podaci korisnika nisu kompletni.");
      }
    } else {
      console.error("Greška: Forma nije validna.");
    }
  }

  public onObrisiKorisnika(): void {
    if (this.obrisiKorisnika && this.obrisiKorisnika.id) {
      this.korisnikServis.deleteKorisnik(this.obrisiKorisnika.id).subscribe({
        next: (response) => {
          console.log(response);
          this.getKorisnike();
        }, error: (err) => {
          console.log(err.message);
        }
      });
    }
  }

  public onOpenModal(mode: string, korisnik?: korisnik): void {

    var temp = document.getElementById('main-container') as HTMLElement;
    const myModal = new Modal(temp);

    const button = document.createElement('button');
    button.type = 'button';
    button.style.display = 'none';
    button.setAttribute('data-bs-toggle', 'modal');

    if (mode === 'add') {
      button.setAttribute('data-bs-target', '#dodajKorisnikaModal');
    }

    if (mode === 'uredi') {
      console.log("Uredi pozvan.");

      if (korisnik != null) {
        //myModal.show();
        console.log("THIS IN MODAL OPEN " + this.urediKorisnika);
        this.urediKorisnika = { ...korisnik };
      }

      button.setAttribute('data-bs-target', '#urediKorisnikaModal');
    }

    if (mode === 'obrisi') {

      console.log('Obrisi pozvan.')

      if (korisnik) {
        this.obrisiKorisnika = korisnik;
      }

      button.setAttribute('data-bs-target', '#obrisiKorisnikaModal');
    }

    if (temp != null) {
      temp.appendChild(button);
    }

    button.click();
  }

  public onCloseModal(): void {
    this.urediModal.nativeElement.style.display = 'none';
    this.urediModal.nativeElement.classList.remove('show');
  }
}
