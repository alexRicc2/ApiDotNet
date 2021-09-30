using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private static List<Filme> filmes = new List<Filme>();
        private static int id = 1;
        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] Filme filme)
        {
            filme.Id = id++;
            filmes.Add(filme);
            Console.WriteLine(filme.Titulo);
            return CreatedAtAction(nameof(RecuperaFilmePorId), new { Id = filme.Id }, filme);
        }

        [HttpGet]
        public IActionResult RecuperarFilmes(){
          return Ok(filmes);
        }
        
        [HttpGet ("{id}")]
        public IActionResult RecuperaFilmePorId(int id){
          
          //sintax do c#
          Filme filme = filmes.FirstOrDefault(filme => filme.Id == id); 
          if(filme != null){
            return Ok(filme);
          }
          return NotFound();

          /* sintax comum
          foreach (Filme filme in filmes)
          {
            if(filme.Id == id){
              return filme;
            }
          }
          return null;*/
        }
    }
}