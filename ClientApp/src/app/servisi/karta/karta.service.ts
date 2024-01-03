import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { karta } from '../../../models/karta';

@Injectable({
  providedIn: 'root'
})
export class KartaService {

  private apiServerUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  public getKarte(): Observable<karta[]> {
    return this.http.get<karta[]>(`${this.apiServerUrl}/Karta`);
  }

  public addKarta(karta: karta): Observable<karta> {
    return this.http.post<karta>(`${this.apiServerUrl}/Karta`, karta);
  }

  public updateKarta(karta: karta): Observable<karta> {
    return this.http.put<karta>(`${this.apiServerUrl}/Karta`, karta);
  }

  public deleteKarta(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiServerUrl}/Karta/${id}`);
  }
}
