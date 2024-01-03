import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { korisnik } from '../../../models/korisnik';

@Injectable({
  providedIn: 'root'
})
export class KorisnikService {

  private apiServiceUrl = environment.apiUrl;
  constructor(private http: HttpClient) { }

  public getKorisnici(): Observable<korisnik[]> {
    return this.http.get<korisnik[]>(`${this.apiServiceUrl}/Korisnik`);
  }

  public getKorisnik(id: number): Observable<korisnik> {
    return this.http.get<korisnik>(`${this.apiServiceUrl}/Korisnik/${id}`);
  }

  public addKorisnik(korisnik: korisnik): Observable<korisnik> {
    return this.http.post<korisnik>(`${this.apiServiceUrl}/Korisnik`, korisnik);
  }

  public updateKorisnik(korisnik: korisnik): Observable<korisnik> {
    return this.http.put<korisnik>(`${this.apiServiceUrl}/Korisnik`, korisnik);
  }

  public deleteKorisnik(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiServiceUrl}/Korisnik/${id}`);
  }

  public dohvatiKorisnike(): Observable<korisnik[]> {
    return this.http.get<korisnik[]>(`${this.apiServiceUrl}/Korisnik`);
  }

  public dohvatiKorisnika(id: number): Observable<korisnik> {
    return this.http.get<korisnik>(`${this.apiServiceUrl}/Korisnik/${id}`);
  }
}
