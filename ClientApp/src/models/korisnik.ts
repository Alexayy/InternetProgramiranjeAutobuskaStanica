export interface korisnik {
  id: 0;
  ime: string;
  prezime: string;
  email: string;
  uloga: 'korisnik' | 'admin';
  slikaKorisnika: string;
}
