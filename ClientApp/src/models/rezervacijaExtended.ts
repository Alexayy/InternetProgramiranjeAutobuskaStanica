export interface RezervacijaExtended {
  id: number;
  linijaID: number;
  sedisteID: number;
  korisnikID: string;
  linijaPolaznaStanica: string;
  linijaDolaznaStanica: string;
  vremePolaska: Date;
  korisnikIme: string;
  korisnikPrezime: string | undefined;
  korisnikEmail: string;
}
