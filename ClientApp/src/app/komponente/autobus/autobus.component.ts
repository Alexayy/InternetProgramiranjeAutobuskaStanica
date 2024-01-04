/* eslint-disable no-var */
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { autobus } from '../../../models/autobus';
import { AutobusService } from '../../servisi/autobus/autobus.service';
import { NgForm } from "@angular/forms";
import * as $ from 'jquery';
import { Modal } from 'bootstrap';

@Component({
  selector: 'app-autobus',
  templateUrl: './autobus.component.html',
  styleUrls: ['./autobus.component.css']
})

export class AutobusComponent implements OnInit {
  @ViewChild('urediModal') urediModal!: ElementRef;

  public autobusi: autobus[] = [];
  public urediAutobus: autobus = { id: 0, marka: '', model: '',
    brojSedista: 0, sedisteKompanije: '',
    brojTelefonaKompanije: '', emailKompanije: '',
    sajtKompanije: '', slikaAutobusa: ''
  };
  public obrisiAutobus: autobus | undefined;

  constructor(private autobusServis: AutobusService) { }

  ngOnInit(): void {
    this.getAutobus();
  }

  public getAutobus(): void {
    this.autobusServis.getAutobusi().subscribe({
      next: (response) => {
        this.autobusi = response;
        console.log(this.autobusi);
      }, error: (err) => {
        console.log(err.message());
      }
    });
  }

  public onDodajAutobus(addForm: NgForm): void {
    if (addForm.valid) {
      this.autobusServis.addAutobus(addForm.value).subscribe({
        next: (response) => {
          console.log("Autobus uspešno dodat", response);
          this.getAutobus(); // Osvežava listu autobusa
          addForm.reset(); // Resetuje formu
        },

        error: (error) => {
          console.error("Došlo je do greške prilikom dodavanja autobusa", error);
        }
      });
    } else {
      console.error("Greška: Forma nije validna.");
    }
  }

  public onUrediAutobus(editForm: NgForm): void {
    // Proveravamo da li forma ima validne podatke
    console.log("Kakva je forma? " + editForm);

    if (editForm.valid) {
      const updatedAutobus = editForm.value;
      
      if (updatedAutobus && updatedAutobus.id) {
        this.autobusServis.updateAutobus(updatedAutobus).subscribe({
          next: (response) => {
            console.log("Autobus uspešno ažuriran", response);
            this.getAutobus();
          },
          error: (err) => {
            console.error("Došlo je do greške prilikom ažuriranja autobusa", err);
          }
        });
      } else {
        console.error("Greška: Podaci autobusa nisu kompletni.");
      }
    } else {
      console.error("Greška: Forma nije validna.");
    }
  }

  public onObrisiAutobus(): void {
    if (this.obrisiAutobus && this.obrisiAutobus.id) {
      this.autobusServis.deleteAutobus(this.obrisiAutobus.id).subscribe({
        next: (response) => {
          console.log(response);
          this.getAutobus();
        }, error: (err) => {
          console.log(err.message);
        }
      });
    }
  }

  public onOpenModal(mode: string, autobus?: autobus): void {

    var temp = document.getElementById('main-container') as HTMLElement;
    const myModal = new Modal(temp);

    const button = document.createElement('button');
    button.type = 'button';
    button.style.display = 'none';
    button.setAttribute('data-bs-toggle', 'modal');

    if (mode === 'add') {
      button.setAttribute('data-bs-target', '#dodajAutobusModal');
    }

    if (mode === 'uredi') {
      console.log("Uredi pozvan.");

      if (autobus != null) {
        //myModal.show();
        console.log("THIS IN MODAL OPEN " + this.urediAutobus);
        this.urediAutobus = { ...autobus };
      }

      button.setAttribute('data-bs-target', '#urediAutobusModal');
    }

    if (mode === 'obrisi') {

      console.log('Obrisi pozvan.')

      if (autobus) {
        this.obrisiAutobus = autobus;
      }

      button.setAttribute('data-bs-target', '#obrisiAutobusModal');
    }

    if (temp != null) {
      temp.appendChild(button);
    }

    button.click();
  }

  public onCloseModal(): void {
    this.urediModal.nativeElement.style.display = 'none';
    this.urediModal.nativeElement.classList.remove('show');
  }
}
