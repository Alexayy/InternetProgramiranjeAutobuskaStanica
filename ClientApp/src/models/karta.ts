import { korisnikKarta } from "./korisnikKarta";

export interface karta {
  id: number;
  rezervacijaID: number;
  datumKupovine: Date;
  karteKorisnika?: korisnikKarta[]; 
}
