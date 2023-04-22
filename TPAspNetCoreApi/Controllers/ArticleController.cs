using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TPAspNetCoreApi.Data;
using TPAspNetCoreApi.Models;

namespace TPAspNetCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly Magasin _magasin;
        public ArticleController(Magasin magasin)
        {
            _magasin = magasin;
        }

        [HttpGet]
        public async Task<ActionResult<List<Article>>> Liste()
        {
            return await _magasin.Article.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Article>> Specifique(int id)
        {
            var article = await _magasin.Article.FindAsync(id);

            if (article == null)
            {
                return NotFound();
            }
            return article;
        }

        [HttpPost]
        public async Task<ActionResult<Article>> Ajout(Article article)
        {
            await _magasin.Article.AddAsync(article);
            await _magasin.SaveChangesAsync();
            return CreatedAtAction(nameof(Specifique), new { id = article.ID }, article);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<List<Article>>> Modification(int id, Article article)
        {
            if (id != article.ID)
            {
                return BadRequest();
            }

            _magasin.Entry(article).State = EntityState.Modified;
            await _magasin.SaveChangesAsync();

            return NoContent();
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult<List<Article>>> Suppression(int id)
        {
            var article = await _magasin.Article.FindAsync(id);

            if (article == null)
            {
                return NotFound();
            }

            _magasin.Article.Remove(article);
            await _magasin.SaveChangesAsync();

            return NoContent();
        }


    }

    
}
