import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { AutobusComponent } from './komponente/autobus/autobus.component';
import { KartaComponent } from './komponente/karta/karta.component';
import { KorisnikComponent } from './komponente/korisnik/korisnik.component';
import { KorisnikKartaComponent } from './komponente/korisnik-karta/korisnik-karta.component';
import { LinijaComponent } from './komponente/linija/linija.component';
import { RezervacijaComponent } from './komponente/rezervacija/rezervacija.component';
import { StajalisteComponent } from './komponente/stajaliste/stajaliste.component';
import { StanicaComponent } from './komponente/stanica/stanica.component';
import * as AnythingThatIsNotDollarSignOrSymbolOrjQuery from "jquery";
import { SignInGoogleComponent } from './sign-in-google/sign-in-google.component'

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    AutobusComponent,
    KartaComponent,
    KorisnikComponent,
    KorisnikKartaComponent,
    LinijaComponent,
    RezervacijaComponent,
    StajalisteComponent,
    StanicaComponent,
    SignInGoogleComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ApiAuthorizationModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'autobusi', component: AutobusComponent },
      { path: 'karte', component: KartaComponent },
      { path: 'korisnik', component: KorisnikComponent },
      { path: 'korisnik-karte', component: KorisnikKartaComponent },
      { path: 'linija', component: LinijaComponent },
      { path: 'rezervacija', component: RezervacijaComponent },
      { path: 'stanica', component: StanicaComponent },
      { path: 'stajaliste', component: StajalisteComponent },
      { path: 'signin-google', component: SignInGoogleComponent },
    ])
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
