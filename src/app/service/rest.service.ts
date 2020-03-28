import { Injectable,  } from '@angular/core';
import{HttpClient} from '@angular/common/http';
import{Observable} from 'rxjs';
import {TiendaI} from '../model/tienda.interface';

@Injectable({
  providedIn: 'root'
})
export class RestService {
  private urlApi='https://tiendaproducto.azurewebsites.net/Producto';

  constructor(private http:HttpClient) {  }

GetAllTienda():Observable<TiendaI[]>{
  return this.http.get<TiendaI[]>(this.urlApi);
}

addNewTienda(tienda:TiendaI):Observable<TiendaI>{
  return this.http.post<TiendaI>(this.urlApi,tienda)
}

}


