import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { stajaliste } from '../../../models/stajaliste';
import { StajalisteService } from '../../servisi/stajaliste/stajaliste.service';
import { Modal } from 'bootstrap';

@Component({
  selector: 'app-stajaliste',
  templateUrl: './stajaliste.component.html',
  styleUrls: ['./stajaliste.component.css']
})
export class StajalisteComponent implements OnInit {
  public stajalista: stajaliste[] = [];
  public urediStajaliste: stajaliste = {
    id: 0, linijaID: 0, stanicaID: 0
  };
  public obrisiStajaliste: stajaliste | undefined;

  constructor(private stajalisteService: StajalisteService) { }

  ngOnInit(): void {
    this.getStajalista();
  }

  public getStajalista(): void {
    this.stajalisteService.getStajalista().subscribe({
      next: (response) => {
        this.stajalista = response;
      },
      error: (err) => {
        console.error('Greška prilikom dohvatanja stajališta', err);
      }
    });
  }

  public onDodajStajaliste(addForm: NgForm): void {
    if (addForm.valid) {
      const novoStajaliste: stajaliste = {
        id: 0, 
        linijaID: addForm.value.linijaId,
        stanicaID: addForm.value.stanicaId
      };

      this.stajalisteService.addStajaliste(novoStajaliste).subscribe({
        next: () => {
          this.getStajalista(); 
          addForm.reset();
        },
        error: (error) => {
          console.error('Greška prilikom dodavanja stajališta', error);
        }
      });
    } else {
      console.error('Greška: Forma nije validna.');
    }
  }

  public onUrediStajaliste(editForm: NgForm): void {
    if (editForm.valid && this.urediStajaliste.id) {
      const uredjenoStajaliste: stajaliste = {
        ...this.urediStajaliste,
        linijaID: editForm.value.linijaId,
        stanicaID: editForm.value.stanicaId
      };

      this.stajalisteService.updateStajaliste(uredjenoStajaliste).subscribe({
        next: () => {
          this.getStajalista(); 
        },
        error: (err) => {
          console.error('Greška prilikom ažuriranja stajališta', err);
        }
      });
    } else {
      console.error('Greška: Forma nije validna ili podaci nisu kompletni.');
    }
  }

  public onObrisiStajaliste(): void {
    if (this.obrisiStajaliste && this.obrisiStajaliste.id) {
      this.stajalisteService.deleteStajaliste(this.obrisiStajaliste.id).subscribe({
        next: () => {
          this.getStajalista(); 
        },
        error: (err) => {
          console.error('Greška prilikom brisanja stajališta', err);
        }
      });
    }
  }

  public onOpenModal(mode: string, stajaliste?: stajaliste): void {
    const temp = document.getElementById('main-container') as HTMLElement;
    const button = document.createElement('button');
    button.type = 'button';
    button.style.display = 'none';
    button.setAttribute('data-bs-toggle', 'modal');

    if (mode === 'add') {
      button.setAttribute('data-bs-target', '#dodajStajalisteModal');
    }

    if (mode === 'uredi') {
      if (stajaliste) {
        this.urediStajaliste = { ...stajaliste };
      }
      button.setAttribute('data-bs-target', '#urediStajalisteModal');
    }

    if (mode === 'obrisi') {
      if (stajaliste) {
        this.obrisiStajaliste = stajaliste;
      }
      button.setAttribute('data-bs-target', '#obrisiStajalisteModal');
    }

    temp.appendChild(button);
    button.click();
  }

}
