import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sign-in-google',
  templateUrl: './sign-in-google.component.html',
  styleUrls: ['./sign-in-google.component.css']
})
export class SignInGoogleComponent implements OnInit {
  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit() {
    const token = new URLSearchParams(window.location.search).get('token');
    if (token) {
      localStorage.setItem('auth_token', token);
      this.router.navigate(['/']);
    } else {
      this.http.get<any>('https://localhost:5285/signin-google')
        .subscribe(response => {
          window.location.href = response.url;
        }, error => {
          console.error('Greška prilikom autentikacije sa Google-om', error);
        });
    }
  }
}
