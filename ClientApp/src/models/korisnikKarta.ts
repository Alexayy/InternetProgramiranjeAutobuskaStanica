import { karta } from "./karta";
import { korisnik } from "./korisnik";

export interface korisnikKarta {
  id: number;
  korisnikId: number;
  kartaId: number;
  korisnik?: korisnik; 
  karta?: karta;
}
