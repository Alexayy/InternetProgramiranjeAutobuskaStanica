import { Component, OnInit } from '@angular/core';
import { autobus } from '../../../models/autobus';
import { AutobusService } from '../../servisi/autobus/autobus.service';

@Component({
  selector: 'app-autobus',
  templateUrl: './autobus.component.html',
  styleUrls: ['./autobus.component.css']
})
export class AutobusComponent implements OnInit {

  public autobusi: autobus[] = {} as autobus[];
  public srediAutobus: autobus | undefined;
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
  
}
