import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { stajaliste } from '../../../models/stajaliste';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class StajalisteService {
  private apiServiceUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  public getStajalista(): Observable<stajaliste[]> {
    return this.http.get<stajaliste[]>(`${this.apiServiceUrl}/Stajaliste`);
  }

  public getStajaliste(id: number): Observable<stajaliste> {
    return this.http.get<stajaliste>(`${this.apiServiceUrl}/Stajaliste/${id}`);
  }

  public addStajaliste(staj: stajaliste): Observable<stajaliste> {
    return this.http.post<stajaliste>(`${this.apiServiceUrl}/Stajaliste`, staj);
  }

  public updateStajaliste(staj: stajaliste): Observable<any> {
    return this.http.put(`${this.apiServiceUrl}/Stajaliste/${staj.id}`, staj);
  }

  public deleteStajaliste(id: number): Observable<any> {
    return this.http.delete(`${this.apiServiceUrl}/Stajaliste/${id}`);
  }
}
