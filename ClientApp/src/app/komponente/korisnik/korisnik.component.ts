import { Component, OnInit } from '@angular/core';
import { korisnik } from '../../../models/korisnik';
import { KorisnikService } from '../../servisi/korisnik/korisnik.service';
import { AuthService } from '../../servisi/auth/auth.service';

@Component({
  selector: 'app-korisnik',
  templateUrl: './korisnik.component.html',
  styleUrls: ['./korisnik.component.css']
})
export class KorisnikComponent implements OnInit {

  public korisnici: korisnik[] = {} as korisnik[];
  public urediKorisnika: korisnik | undefined;
  public obrisiKorisnik: korisnik | undefined;

  constructor(private korisnikServis: KorisnikService, private authServis: AuthService) { }

  ngOnInit(): void {
    this.proveriTipKorisnikaIUcitajPodatke();
  }

  private proveriTipKorisnikaIUcitajPodatke(): void {
    const tipKorisnika = this.authServis.dohvatiTipTrenutnogKorisnika();

    if (tipKorisnika === 'admin') {
      this.dohvatiKorisnike();
    } else {
      this.dohvatiKorisnika(this.authServis.dohvatiIdTrenutnogKorisnika());
    }
  }

  private dohvatiKorisnike(): void {
    this.korisnikServis.dohvatiKorisnike().subscribe({
      next: (odgovor) => {
        this.korisnici = odgovor;
        console.log(this.korisnici);
      },
      error: (err) => {
        console.log(err.message());
      }
    });
  }

  private dohvatiKorisnika(id: number): void {
    this.korisnikServis.dohvatiKorisnika(id).subscribe({
      next: (odgovor) => {
        this.korisnici = [odgovor];
      },
      error: (err) => {
        console.log(err.message());
      }
    });
  }

  public dodajNovogKorisnika(noviKorisnik: korisnik): void {
    this.korisnikServis.addKorisnik(noviKorisnik).subscribe({
      next: (odgovor) => {
        this.korisnici.push(odgovor);
      },
      error: (err) => {
        console.log(err.message());
      }
    });
  }

  public urediPostojecegKorisnika(izmenjenKorisnik: korisnik): void {
    this.korisnikServis.updateKorisnik(izmenjenKorisnik).subscribe({
      next: () => {
        this.korisnikServis.getKorisnici();
      },
      error: (err) => {
        console.log(err.message());
      }
    });
  }

  public obrisiKorisnika(id: number): void {
    this.korisnikServis.deleteKorisnik(id).subscribe({
      next: () => {
        this.korisnici = this.korisnici.filter(korisnik => korisnik.id !== id);
      },
      error: (err) => {
        console.log(err.message());
      }
    });
  }
}
