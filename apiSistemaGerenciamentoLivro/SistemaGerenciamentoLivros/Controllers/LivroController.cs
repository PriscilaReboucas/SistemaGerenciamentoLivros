using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SistemaGerenciamentoLivros.Data;
using SistemaGerenciamentoLivros.Models;

namespace SistemaGerenciamentoLivros.Controllers
{
    public class LivroController : ApiController
    {
        private LivrariaContext db = new LivrariaContext();

        /// <summary>
        /// Rotina que retorna todos os livros.
        /// </summary>
        /// <returns></returns>
        public IQueryable<Livro> GetLivros()
        {
            return db.Livros.Include(x => x.Editora).Include(a => a.Autor)?.OrderBy(x => x.Nome);
        }

        /// <summary>
        /// //Rotina responsável pelo retorno do livro passando como parâmetro o id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(Livro))]
        public IHttpActionResult GetLivro(int id)
        {
            Livro livro = db.Livros.Find(id);
            if (livro == null)
            {
                return NotFound();
            }

            return Ok(livro);
        }

        /// <summary>
        /// Rotina responsável pela atualização do livro
        /// </summary>
        /// <param name="id"></param>
        /// <param name="livro"></param>
        /// <returns></returns>
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLivro(int id, Livro livro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != livro.IdLivro)
            {
                return BadRequest();
            }

            db.Entry(livro).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VerificarExistenciaLivro(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Rotina responsável pela criação do livro
        /// </summary>
        /// <param name="livro"></param>
        /// <returns></returns>
        [ResponseType(typeof(Livro))]
        public IHttpActionResult PostLivro(Livro livro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (livro != null)
            {
                db.Livros.Add(livro);
                db.SaveChanges();
            }

            //cria rota de retorno
            return CreatedAtRoute("DefaultApi", new { id = livro?.IdLivro }, livro?.Nome);
        }

        /// <summary>
        /// Rotina responsavel pela exclusão do livro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(Livro))]
        public IHttpActionResult DeleteLivro(int id)
        {
            Livro livro = db.Livros.Find(id);
            if (livro == null)
            {
                return NotFound();
            }

            db.Livros.Remove(livro);
            db.SaveChanges();

            return Ok(livro);
        }

        /// <summary>
        /// Rotina responsável por remover da memória o objeto utilizado.
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Rotina responsável por verificar se o livro existe.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool VerificarExistenciaLivro(int id)
        {
            return db.Livros.Count(e => e.IdLivro == id) > 0;
        }
    }
}