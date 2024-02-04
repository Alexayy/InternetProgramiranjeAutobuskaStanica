import { Component, OnInit } from '@angular/core';
import { korisnikKarta } from '../../../models/korisnikKarta';
import { KorisnikKartaService } from '../../servisi/korisnik-karta/korisnik-karta.service';
import { NgForm } from '@angular/forms';
import { KorisnikService } from '../../servisi/korisnik/korisnik.service';
import { KartaService } from '../../servisi/karta/karta.service';
import { KorisnikKartaExtended } from '../../../models/korisnikKartaExtended';

@Component({
  selector: 'app-korisnik-karta',
  templateUrl: './korisnik-karta.component.html',
  styleUrls: ['./korisnik-karta.component.css']
})
export class KorisnikKartaComponent implements OnInit {
  public korisnikKarte: korisnikKarta[] = [];
  public urediKorisnikKarta: korisnikKarta = {
    id: 0, korisnikID: '', kartaID: 0
  };
  public obrisiKorisnikKartu: korisnikKarta | undefined;
  public korisnikKarteExtended: KorisnikKartaExtended[] = [];

  constructor(private korisnikKartaService: KorisnikKartaService,
    private korisnikService: KorisnikService, private kartaService: KartaService) { }

  ngOnInit(): void {
    this.getKorisnikKarte();
  }
 
  public getKorisnikKarte(): void {
    this.korisnikKartaService.getKorisnikKarte().subscribe({
      next: (response) => {
        response.forEach(kk => {
          this.korisnikService.getKorisnik(kk.korisnikID).subscribe(korisnik => {
            this.kartaService.getKarta(kk.kartaID).subscribe(karta => {
              let extendedKorisnikKarta: KorisnikKartaExtended = {
                ...kk,
                korisnikEmail: korisnik.email,
                korisnikIme: korisnik.userName,
                rezervacijaID: karta.rezervacijaID
              };
              this.korisnikKarteExtended.push(extendedKorisnikKarta);
            });
          });
        });
      },
      error: (err) => {
        console.error('Greška prilikom dohvatanja veza korisnik-karta', err);
      }
    });
  }

  
  public onDodajKorisnikKartu(addForm: NgForm): void {
    if (addForm.valid) {
      const korisnikId = addForm.value.korisnikID;
      const kartaId = addForm.value.kartaID;

      this.korisnikKartaService.addKorisnikKarta(korisnikId, kartaId).subscribe({
        next: (response) => {
          this.korisnikKarte.push(response);
          addForm.reset();
          this.getKorisnikKarte();
        },
        error: (error) => {
          console.error('Greška prilikom dodavanja veze korisnik-karta', error);
        }
      });
    } else {
      console.error('Greška: Forma nije validna.');
    }
  }

  public onUrediKorisnikKartu(editForm: NgForm): void {
    if (editForm.valid && this.urediKorisnikKarta.id) {
      this.korisnikKartaService.updateKorisnikKarta(this.urediKorisnikKarta).subscribe({
        next: () => {
          this.getKorisnikKarte();
        },
        error: (err) => {
          console.error('Greška prilikom ažuriranja veze korisnik-karta', err);
        }
      });
    } else {
      console.error('Greška: Forma nije validna ili podaci nisu kompletni.');
    }
  }

  public onObrisiKorisnikKartu(): void {
    if (this.obrisiKorisnikKartu && this.obrisiKorisnikKartu.id) {
      this.korisnikKartaService.deleteKorisnikKarta(this.obrisiKorisnikKartu.id).subscribe({
        next: () => {
          this.getKorisnikKarte();
        },
        error: (err) => {
          console.error('Greška prilikom brisanja veze korisnik-karta', err);
        }
      });
    }
  }
}
