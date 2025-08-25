import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IToy } from '../../interfaces/IToy';
import { IResponse } from '../../interfaces/IResponse';

@Injectable({
  providedIn: 'root'
})
export class ToyService {
  
  private _urlBase: string = 'https://localhost:44318/api/';

  constructor(
    private _http: HttpClient
  ) {}

  getAll(): Observable<IResponse<Array<IToy>>> {
    return this._http.get<IResponse<Array<IToy>>>(`${this._urlBase}Toy/GetAll`);
  }

  getById(toyId: number): Observable<IResponse<IToy>> {
    return this._http.get<IResponse<IToy>>(`${this._urlBase}Toy/GetById/${toyId}`);
  }

  create(toy: IToy): Observable<IResponse<boolean>> {
    return this._http.post<IResponse<boolean>>(`${this._urlBase}Toy/Create`, toy);
  }

  update(toy: IToy): Observable<IResponse<boolean>> {
    return this._http.put<IResponse<boolean>>(`${this._urlBase}Toy/Update`, toy);
  }
  
  delete(toyId: number): Observable<IResponse<boolean>> {
    return this._http.delete<IResponse<boolean>>(`${this._urlBase}Toy/Delete/${toyId}`);
  }
}
