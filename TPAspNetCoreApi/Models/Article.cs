using System.ComponentModel.DataAnnotations.Schema;

namespace TPAspNetCoreApi.Models
{
    public enum Categorie
    {
        Camping,
        Velo
    }
    public class Article
    {
        public int ID { get; set; }
        public required string Nom { get; set; }
        public required string Description { get; set; }
        public required Categorie Categorie { get; set; }
        [Column(TypeName = "decimal(6,2)")]
        public required decimal Prix { get; set; }
        public List<Transaction> Transactions { get; set; } = new();
    }
}
