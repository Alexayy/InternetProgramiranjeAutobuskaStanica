import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { rezervacija } from '../../../models/rezervacija';
import { RezervacijaService } from '../../servisi/rezervacija/rezervacija.service';
import { LinijaService } from '../../servisi/linija/linija.service';
import { KorisnikService } from '../../servisi/korisnik/korisnik.service';
import { RezervacijaExtended } from '../../../models/rezervacijaExtended';
import { Modal } from 'bootstrap';

@Component({
  selector: 'app-rezervacija',
  templateUrl: './rezervacija.component.html',
  styleUrls: ['./rezervacija.component.css']
})
export class RezervacijaComponent implements OnInit {
  public rezervacije: rezervacija[] = [];
  public urediRezervaciju: rezervacija = {
    id: 0, linijaID: 0, sedisteID: 0, korisnikID: 0
  };
  public obrisiRezervaciju: rezervacija | undefined;
  public rezervacijeExtended: RezervacijaExtended[] = [];

  constructor(private rezervacijaService: RezervacijaService,
    private linijaService: LinijaService,
    private korisnikService: KorisnikService) { }

  ngOnInit(): void {
    this.getRezervacije();
  }

  public getRezervacije(): void {
    this.rezervacijaService.getRezervacije().subscribe({
      next: (response) => {
        response.forEach(r => {
          this.linijaService.getLinija(r.linijaID).subscribe(linija => {

            this.korisnikService.getKorisnik(r.korisnikID).subscribe(korisnik => {
              let extendedRezervacija: RezervacijaExtended = {
                ...r,
                linijaPolaznaStanica: linija.polaznaStanica,
                linijaDolaznaStanica: linija.dolaznaStanica,
                vremePolaska: linija.vremePolaska,
                korisnikIme: korisnik.ime,
                korisnikPrezime: korisnik.prezime,
                korisnikEmail: korisnik.email
              };
              this.rezervacijeExtended.push(extendedRezervacija);
            });

          });

        });
      },
      error: (err) => {
        console.error('Greška prilikom dohvatanja rezervacija', err);
      }
    });
  }

  public onDodajRezervaciju(addForm: NgForm): void {
    if (addForm.valid) {
      let novaRezervacija = {
        ...addForm.value
      };

      this.rezervacijaService.addRezervacija(novaRezervacija).subscribe({
        next: (response) => {
          this.getRezervacije(); // Osveži listu nakon dodavanja
          window.location.reload();
          addForm.reset();
        },
        error: (error) => {
          console.error('Greška prilikom dodavanja rezervacije', error);
        }
      });
    } else {
      console.error('Greška: Forma nije validna.');
    }
  }

  public onUrediRezervaciju(editForm: NgForm): void {
    if (editForm.valid && this.urediRezervaciju.id) {

      this.rezervacijaService.updateRezervacija(this.urediRezervaciju).subscribe({
        next: () => {
          this.getRezervacije(); // Osveži listu nakon uređivanja
          window.location.reload();
        },
        error: (err) => {
          console.error('Greška prilikom ažuriranja rezervacije', err);
        }
      });
    } else {
      console.error('Greška: Forma nije validna ili podaci nisu kompletni.');
    }
  }

  public onObrisiRezervaciju(): void {
    if (this.obrisiRezervaciju && this.obrisiRezervaciju.id) {
      this.rezervacijaService.deleteRezervacija(this.obrisiRezervaciju.id).subscribe({
        next: () => {
          this.getRezervacije(); // Osveži listu nakon brisanja
          window.location.reload();
        },
        error: (err) => {
          console.error('Greška prilikom brisanja rezervacije', err);
        }
      });
    }
  }

  public onOpenModal(mode: string, rezervacija?: rezervacija): void {

    var temp = document.getElementById('main-container') as HTMLElement;
    const myModal = new Modal(temp);

    const button = document.createElement('button');
    button.type = 'button';
    button.style.display = 'none';
    button.setAttribute('data-bs-toggle', 'modal');

    if (mode === 'add') {
      button.setAttribute('data-bs-target', '#dodajRezervacijuModal');
    }

    if (mode === 'uredi') {
      console.log("Uredi pozvan.");

      if (rezervacija != null) {
        //myModal.show();
        console.log("THIS IN MODAL OPEN " + this.urediRezervaciju);
        this.urediRezervaciju = { ...rezervacija };
      }

      button.setAttribute('data-bs-target', '#urediRezervacijuModal');
    }

    if (mode === 'obrisi') {

      console.log('Obrisi pozvan.')

      if (rezervacija) {
        this.obrisiRezervaciju = rezervacija;
      }

      button.setAttribute('data-bs-target', '#obrisiRezervacijuModal');
    }

    if (temp != null) {
      temp.appendChild(button);
    }

    button.click();
  }

}
