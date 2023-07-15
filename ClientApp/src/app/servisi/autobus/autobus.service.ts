import { Injectable } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http'
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { autobus } from '../../../models/autobus';

@Injectable({
  providedIn: 'root'
})
export class AutobusService {

  private apiServerUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  public getAutobusi(): Observable<autobus[]> {
    return this.http.get<autobus[]>(`${this.apiServerUrl}/Autobus`);
  }

  public addAutobus(autobus: autobus): Observable<autobus> {
    return this.http.post<autobus>(`${this.apiServerUrl}/Autobus`, autobus);
  }

  public updateAutobus(autobus: autobus): Observable<autobus> {
    return this.http.put<autobus>(`${this.apiServerUrl}/Autobus`, autobus);
  }

  public deleteAutobus(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiServerUrl}/Autobus/${id}`);
  }
 
}
