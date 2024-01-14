import { Component } from '@angular/core';

@Component({
  selector: 'app-sign-in-google',
  templateUrl: './sign-in-google.component.html',
  styleUrls: ['./sign-in-google.component.css']
})
export class SignInGoogleComponent implements OnInit {
  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.http.get('https://localhost:5285/signin-google')
      .subscribe((response: any) => {
        // Obrada response-a
      }, error: (err) => {
        console.error('Greška prilikom autentikacije sa Google-om', error);
      });
  }
}
