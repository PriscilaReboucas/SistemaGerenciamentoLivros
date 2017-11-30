import { Component, OnInit } from '@angular/core';
import { LivroService } from './livro.service';
import { Livro } from '../models/livro';

@Component({
  selector: 'app-home',
  templateUrl: './livro.component.html',
  styleUrls: ['./livro.component.css']
})
export class HomeComponent implements OnInit {

  public livros: Array<any>;

  public livro: Livro = new Livro();

  constructor(
    private livroService: LivroService,
  ) { }

  ngOnInit() {
    this.carregarLivros();
  }

  private carregarLivros(): void {
    this.livroService.listAll().subscribe(
      data => {
        this.livros = JSON.parse(data._body);
      },
      error => {
        console.log(error);
      });
  }

  public salvar(): void {
    this.livroService.save(this.livro).subscribe(
      data => {
        alert('Cadastrado com sucesso.');
        this.carregarLivros();
        this.limpar();
      },
      error => {
        console.log(error);
      }
    );
  }

  public editar(id: number): void {
    this.livroService.get(id).subscribe(
      data => {
        this.livro = JSON.parse(data._body); // transforma o texto simples em um objeto json
      },
      error => {
        console.log(error);
      }
    );
  }

  public deletar(id: number): void {
    this.livroService.delete(id).subscribe(
      data => {
        this.carregarLivros();
      },
      error => {
        console.log(error);
      }
    );
  }

  public limpar(): void {
    this.livro = new Livro();
  }

}
