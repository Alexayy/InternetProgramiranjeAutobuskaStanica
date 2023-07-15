/* eslint-disable no-var */
import { Component, OnInit } from '@angular/core';
import { autobus } from '../../../models/autobus';
import { AutobusService } from '../../servisi/autobus/autobus.service';
import { NgForm } from "@angular/forms";

@Component({
  selector: 'app-autobus',
  templateUrl: './autobus.component.html',
  styleUrls: ['./autobus.component.css']
})
export class AutobusComponent implements OnInit {

  public autobusi: autobus[] = {} as autobus[];
  public urediAutobus: autobus | undefined;
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
    // eslint-disable-next-line @typescript-eslint/ban-ts-comment
    // @ts-ignore
    document.getElementById("dodaj-autobus-form").click();
    this.autobusServis.addAutobus(addForm.value).subscribe({
      next: (response) => {
        console.log(response);
        this.getAutobus();
        addForm.reset();
      }, error: (error) => {
        alert(error.message);
        addForm.reset();
      }
    });
  }

  public onUrediAutobus(autobus: autobus): void {
    this.autobusServis.updateAutobus(autobus).subscribe({
      next: (response) => {
        console.log(response);
        this.getAutobus();
      }, error: (err) => {
        alert(err.message);
      }
    });
  }

  public onObrisiAutobus(autobusId: number): void {
    if (autobusId != null) {
      this.autobusServis.deleteAutobus(autobusId).subscribe({
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
    var temp = document.getElementById('main-container');
    const button = document.createElement('button');
    button.type = 'button';
    button.style.display = 'none';
    button.setAttribute('data-bs-toggle', 'modal');

    if (mode === 'add') {
      button.setAttribute('data-bs-target', '#dodajAutobusModal');
    }

    if (mode === 'uredi') {

      console.log("Uredi pozvan.")

      if (autobus) {
        console.log(this.urediAutobus);
        this.urediAutobus = autobus;
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
}
