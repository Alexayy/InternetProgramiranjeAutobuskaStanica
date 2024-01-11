import { Component } from '@angular/core';

@Component({
  selector: 'app-sign-in-google',
  templateUrl: './sign-in-google.component.html',
  styleUrls: ['./sign-in-google.component.css']
})
export class SignInGoogleComponent {
  constructor(private authService: AuthService) { }

  signInWithGoogle() {
    this.authService.signInWithGoogle();
  }
}
