import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }

  public trenutniKorisnik(): Observable<any> {
    return this.http.get<any>('/api/trenutnikorisnik');
  }

  public dohvatiTipTrenutnogKorisnika(): string {
    const token = localStorage.getItem('token');
    if (token) {
      const decodedToken = JSON.parse(atob(token.split('.')[1]));
      return decodedToken.tipKorisnika;
    }
    return '';
  }

  public dohvatiIdTrenutnogKorisnika(): number {
    const token = localStorage.getItem('token');
    if (token) {
      const decodedToken = JSON.parse(atob(token.split('.')[1]));
      return decodedToken.id; 
    }
    return 0;
  }
}
