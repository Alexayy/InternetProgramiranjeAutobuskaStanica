import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Korisnik } from '../../../models/korisnik';

@Injectable({
  providedIn: 'root'
})
export class KorisnikService {

  private apiServiceUrl = environment.apiUrl;
  constructor(private http: HttpClient) { }

  public getKorisnici(): Observable<Korisnik[]> {
    return this.http.get<Korisnik[]>(`${this.apiServiceUrl}/Korisnik`);
  }

  public getKorisnik(id: string): Observable<Korisnik> {
    return this.http.get<Korisnik>(`${this.apiServiceUrl}/Korisnik/${id}`);
  }

  public addKorisnik(korisnik: Korisnik): Observable<Korisnik> {
    return this.http.post<Korisnik>(`${this.apiServiceUrl}/Korisnik`, korisnik);
  }

  public updateKorisnik(korisnik: Korisnik): Observable<Korisnik> {
    console.log(`${this.apiServiceUrl}/Korisnik/${korisnik.id}`);
    return this.http.put<Korisnik>(`${this.apiServiceUrl}/Korisnik/${korisnik.id}`, korisnik);
  }

  public deleteKorisnik(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiServiceUrl}/Korisnik/${id}`);
  }

  public dohvatiKorisnike(): Observable<Korisnik[]> {
    return this.http.get<Korisnik[]>(`${this.apiServiceUrl}/Korisnik`);
  }

  public dohvatiKorisnika(id: number): Observable<Korisnik> {
    return this.http.get<Korisnik>(`${this.apiServiceUrl}/Korisnik/${id}`);
  }
}
