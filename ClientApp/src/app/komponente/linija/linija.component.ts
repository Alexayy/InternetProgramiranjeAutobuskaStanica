import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { linija } from '../../../models/linija';
import { LinijaService } from '../../servisi/linija/linija.service';
import { NgForm } from '@angular/forms';
import { Modal } from 'bootstrap';

@Component({
  selector: 'app-linija',
  templateUrl: './linija.component.html',
  styleUrls: ['./linija.component.css']
})
export class LinijaComponent implements OnInit {
  @ViewChild('urediModal') urediModal!: ElementRef;

  public linije: linija[] = [];
  public urediLiniju: linija = { id: 0, polaznaStanica: '', dolaznaStanica: '', vremePolaska: new Date }
  public obrisiLiniju: linija | undefined;

  constructor(private linijaService: LinijaService) { }

  ngOnInit(): void {
    this.getLinije();
  }

  public getLinije(): void {
    this.linijaService.getLinije().subscribe({
      next: (response) => {
        this.linije = response;
        console.log(this.linije);
      },

      error: (err) => {
        console.log(err.message());
      }
    });
  }

  public onDodajLiniju(addForm: NgForm): void {
    if (addForm.valid) {
      let vremePolaska = new Date(addForm.value.vremePolaska).toISOString();
      let novaLinija = { ...addForm.value, vremePolaska: vremePolaska };

      this.linijaService.addLinija(novaLinija).subscribe({
        next: (response) => {
          console.log("Linija uspesno dodata! ", response);
          this.getLinije();
          addForm.reset();
        },

        error: (err) => {
          console.error("Došlo je do greške prilikom dodavanja linije", err);
        }
      });
    } else {
      console.error("Greška: Forma nije validna.");
    }
  }

  public onUrediLiniju(editForm: NgForm): void {
    if (editForm.valid) {
      let vremePolaska = new Date(editForm.value.vremePolaska).toISOString();

      let uredjenaLinija = {
        ...editForm.value,
        id: this.urediLiniju.id,
        vremePolaska: vremePolaska
      }

      if (uredjenaLinija && uredjenaLinija.id) {
        this.linijaService.updateLinija(uredjenaLinija).subscribe({
          next: (response) => {
            console.log("Linija uspesno azurirana! ", response);
            this.getLinije();
          },

          error: (err) => {
            console.error("Došlo je do greške prilikom ažuriranja linije! ", err);
          }
        });
      } else {
        console.error("Greška: Podaci linije nisu kompletni.");
      }
    } else {
      console.error("Greška: Forma nije validna.");
    }
  }

  public onObrisiLiniju(): void {
    if (this.obrisiLiniju && this.obrisiLiniju.id) {
      this.linijaService.deleteLinija(this.obrisiLiniju.id).subscribe({
        next: (response) => {
          console.log(response);
          this.getLinije();
        },

        error: (err) => {
          console.log(err.message());
        }
      });
    }
  }

  public onOpenModal(mode: string, linija?: linija): void {
    var temp = document.getElementById("main-container");
    const button = document.createElement('button');
    button.type = 'button';
    button.style.display = 'none';
    button.setAttribute('data-bs-toggle', 'modal');

    if (mode === 'add') {
      button.setAttribute('data-bs-target', '#dodajLinijuModal');
    }

    if (mode === 'uredi') {
      console.log("Uredi pozvan");

      if (linija != null) {
        console.log("THIS IN MODAL OPEN " + this.urediLiniju);
        this.urediLiniju = { ...linija };
      }

      button.setAttribute('data-bs-target', '#urediLinijuModal');
    }

    if (mode === 'obrisi') {
      console.log('Obrisi pozvan.');

      if (linija) {
        this.obrisiLiniju = linija;
      }

      button.setAttribute('data-bs-target', '#obrisiLinijuModal');
    }

    if (temp != null) {
      temp.appendChild(button);
    }

    button.click();
  }

}
