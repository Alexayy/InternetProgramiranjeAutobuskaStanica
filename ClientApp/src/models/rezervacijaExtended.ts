export interface RezervacijaExtended {
  id: number;
  linijaID: number;
  sedisteID: number;
  korisnikID: number;
  linijaPolaznaStanica: string;
  linijaDolaznaStanica: string;
  vremePolaska: Date;
  korisnikIme: string;
  korisnikPrezime: string;
  korisnikEmail: string;
}
