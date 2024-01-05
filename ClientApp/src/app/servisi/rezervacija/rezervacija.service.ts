import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { rezervacija } from '../../../models/rezervacija';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class RezervacijaService {
  private apiServerUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  public getRezervacije(): Observable<rezervacija[]> {
    return this.http.get<rezervacija[]>(`${this.apiServerUrl}/Rezervacija`);
  }

  public getRezervacija(id: number): Observable<rezervacija> {
    return this.http.get<rezervacija>(`${this.apiServerUrl}/Rezervacija/${id}`);
  }

  public addRezervacija(rezervacija: rezervacija): Observable<rezervacija> {
    return this.http.post<rezervacija>(`${this.apiServerUrl}/Rezervacija`, rezervacija);
  }

  public updateRezervacija(rezervacija: rezervacija): Observable<any> {
    return this.http.put(`${this.apiServerUrl}/Rezervacija/${rezervacija.id}`, rezervacija);
  }

  public deleteRezervacija(id: number): Observable<any> {
    return this.http.delete(`${this.apiServerUrl}/Rezervacija/${id}`);
  }
}
