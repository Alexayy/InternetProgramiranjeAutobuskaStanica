export interface Korisnik {
  id: string;
  userName: string;
  email: string;  
  prezime?: string; 
  uloga?: 'korisnik' | 'admin';  
  slikaKorisnika?: string;
  concurrencyStamp: string;
}
