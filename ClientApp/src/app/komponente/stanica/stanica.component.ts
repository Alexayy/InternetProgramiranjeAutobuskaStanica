import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { stanica } from '../../../models/stanica';
import { StanicaService } from '../../servisi/stanica/stanica.service';

@Component({
  selector: 'app-stanica',
  templateUrl: './stanica.component.html',
  styleUrls: ['./stanica.component.css']
})
export class StanicaComponent implements OnInit {
  public stanice: stanica[] = [];
  public urediStanica: stanica = { id: 0, naziv: '', adresa: '' };
  public obrisiStanica: stanica | undefined;

  constructor(private stanicaService: StanicaService) { }

  ngOnInit(): void {
    this.getStanice();
  }

  public getStanice(): void {
    this.stanicaService.getStanice().subscribe({
      next: (response) => {
        this.stanice = response;
      },
      error: (err) => {
        console.error('Greška prilikom dohvatanja stanica', err);
      }
    });
  }

  public onDodajStanica(addForm: NgForm): void {
    if (addForm.valid) {
      this.stanicaService.addStanica(addForm.value).subscribe({
        next: () => {
          this.getStanice();
          addForm.reset();
        },
        error: (error) => {
          console.error('Greška prilikom dodavanja stanice', error);
        }
      });
    } else {
      console.error('Greška: Forma nije validna.');
    }
  }

  public onUrediStanica(editForm: NgForm): void {
    if (editForm.valid && this.urediStanica.id) {
      this.stanicaService.updateStanica(this.urediStanica).subscribe({
        next: () => {
          this.getStanice();
        },
        error: (err) => {
          console.error('Greška prilikom ažuriranja stanice', err);
        }
      });
    } else {
      console.error('Greška: Forma nije validna ili podaci nisu kompletni.');
    }
  }

  public onObrisiStanica(): void {
    if (this.obrisiStanica && this.obrisiStanica.id) {
      this.stanicaService.deleteStanica(this.obrisiStanica.id).subscribe({
        next: () => {
          this.getStanice();
        },
        error: (err) => {
          console.error('Greška prilikom brisanja stanice', err);
        }
      });
    }
  }
}
