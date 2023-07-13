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
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ApiAuthorizationModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
    ])
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
