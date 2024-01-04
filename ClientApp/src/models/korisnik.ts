export interface korisnik {
  id: number;
  ime: string;
  prezime: string;
  email: string;
  uloga: 'korisnik' | 'admin';
  slikaKorisnika: string;
}
