using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TPAspNetCoreApi.Data;
using TPAspNetCoreApi.Models;

namespace TPAspNetCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : Controller
    {
        private readonly Magasin _magasin;
        public TransactionController(Magasin magasin)
        {
            _magasin = magasin;
        }

        [HttpGet]
        public async Task<ActionResult<List<Transaction>>> Liste()
        {
            return await _magasin.Transaction
                .Include(v => v.Article)
                .ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Transaction>> Specifique(int id)
        {
            var transaction = await _magasin.Transaction.FindAsync(id);

            if (transaction == null)
            {
                return NotFound();
            }
            return transaction;
        }

        [HttpPost]
        public async Task<ActionResult<Transaction>> Ajout(Transaction transaction)
        {
            await _magasin.Transaction.AddAsync(transaction);
            await _magasin.SaveChangesAsync();
            return CreatedAtAction(nameof(Specifique), new { id = transaction.ID }, transaction);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<List<Transaction>>> Modification(int id, Transaction transaction)
        {
            if (id != transaction.ID)
            {
                return BadRequest();
            }

            _magasin.Entry(transaction).State = EntityState.Modified;
            await _magasin.SaveChangesAsync();

            return NoContent();
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult<List<Transaction>>> Suppression(int id)
        {
            var transaction = await _magasin.Transaction.FindAsync(id);

            if (transaction == null)
            {
                return NotFound();
            }

            _magasin.Transaction.Remove(transaction);
            await _magasin.SaveChangesAsync();

            return NoContent();
        }

    }
}
