import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { linija } from '../../../models/linija';

@Injectable({
  providedIn: 'root'
})
export class LinijaService {
  private apiServerUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  public getLinije(): Observable<linija[]> {
    return this.http.get<linija[]>(`${this.apiServerUrl}/Linija`);
  }

  public getLinija(id: number): Observable<linija> {
    return this.http.get<linija>(`${this.apiServerUrl}/Linija/${id}`);
  }

  public addLinija(linija: linija): Observable<linija> {
    return this.http.post<linija>(`${this.apiServerUrl}/Linija`, linija);
  }

  public updateLinija(linija: linija): Observable<void> {
    return this.http.put<void>(`${this.apiServerUrl}/Linija/${linija.id}`, linija);
  }

  public deleteLinija(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiServerUrl}/Linija/${id}`);
  }
}
