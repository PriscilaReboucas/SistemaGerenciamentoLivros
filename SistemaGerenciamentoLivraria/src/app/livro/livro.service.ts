import { Livro } from '../models/livro';
import { Injectable } from '@angular/core';
import { Http, RequestOptions, Headers, ResponseContentType } from '@angular/http';

@Injectable()
export class LivroService {

  private endpoint = 'http://localhost:3000/livro';

  constructor(private http: Http) { }

  public listAll(): any {
    return this.http.get(this.endpoint);
  }

  public get(id: number): any {
    return this.http.get(`${this.endpoint}/${id}`);
  }

  public save(livro: Livro) {
    if (livro.id !== undefined) {
      return this.http.put(`${this.endpoint}/${livro.id}`, livro, new RequestOptions());
    } else {
      return this.http.post(this.endpoint, livro, new RequestOptions());
    }
  }

  public delete(id: number) {
    return this.http.delete(`${this.endpoint}/${id}`, new RequestOptions());
  }

}

