import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { korisnikKarta } from '../../../models/korisnikKarta';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class KorisnikKartaService {
  private apiServiceUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  public getKorisnikKarte(): Observable<korisnikKarta[]> {
    return this.http.get<korisnikKarta[]>(`${this.apiServiceUrl}/KorisnikKarta`);
  }

  public getKorisnikKarta(id: number): Observable<korisnikKarta> {
    return this.http.get<korisnikKarta>(`${this.apiServiceUrl}/KorisnikKarta/${id}`);
  }

  public addKorisnikKarta(korisnikId: number, kartaId: number): Observable<korisnikKarta> {
    const body = { korisnikId, kartaId };
    return this.http.post<korisnikKarta>(`${this.apiServiceUrl}/KorisnikKarta`, body);
  }


  public updateKorisnikKarta(kk: korisnikKarta): Observable<any> {
    return this.http.put(`${this.apiServiceUrl}/KorisnikKarta/${kk.id}`, kk);
  }

  public deleteKorisnikKarta(id: number): Observable<any> {
    return this.http.delete(`${this.apiServiceUrl}/KorisnikKarta/${id}`);
  }
}
