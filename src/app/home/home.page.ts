import { Component } from '@angular/core';
import{RestService} from '../service/rest.service';
import{TiendaI} from '../model/tienda.interface';

@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss'],
})
export class HomePage {
  tienda:TiendaI[];

  constructor( private restSvc:RestService) {
  }
  ngOnInit(){

this.restSvc.GetAllTienda().subscribe(data =>(this.tienda=data));
  }
  saveNew()
  {
    const newTienda={codigo:'8',nombre:'Milano',descripcion:'nada',precio:'222'}
    this.restSvc.addNewTienda(newTienda).subscribe(tienda =>this.tienda.push(tienda))
  }

}
