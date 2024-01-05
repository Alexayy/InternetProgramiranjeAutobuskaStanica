import { karta } from "./karta";
import { korisnik } from "./korisnik";

export interface korisnikKarta {
  id: number;
  korisnikID: number;
  kartaID: number;
  //korisnik?: korisnik; 
  //karta?: karta;
}
