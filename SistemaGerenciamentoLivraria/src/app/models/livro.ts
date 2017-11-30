import { Autor } from './autor';
import { Editora } from './editora';
export class Livro {
    public id: number;
    public nome: string;
    public anoLancamento: number;
    public codigoLivro: number;
    public editora: Editora;
    public autor: Autor;

    constructor() { 
        this.editora = new Editora();
        this.autor = new Autor();
    }
}
