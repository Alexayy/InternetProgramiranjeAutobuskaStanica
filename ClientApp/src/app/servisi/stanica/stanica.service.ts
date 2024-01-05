import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { stanica } from '../../../models/stanica';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class StanicaService {
  private apiServerUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  public getStanice(): Observable<stanica[]> {
    return this.http.get<stanica[]>(`${this.apiServerUrl}/Stanica`);
  }

  public addStanica(stanica: stanica): Observable<stanica> {
    return this.http.post<stanica>(`${this.apiServerUrl}/Stanica`, stanica);
  }

  public updateStanica(stanica: stanica): Observable<stanica> {
    return this.http.put<stanica>(`${this.apiServerUrl}/Stanica/${stanica.id}`, stanica);
  }

  public deleteStanica(stanicaId: number): Observable<void> {
    return this.http.delete<void>(`${this.apiServerUrl}/Stanica/${stanicaId}`);
  }
}
