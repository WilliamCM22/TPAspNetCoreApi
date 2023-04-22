using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPAspNetCoreApi.Models
{
    public class Transaction
    {
        public int ID { get; set; }
        public required DateTime Moment { get; set; }
        public required Article Article { get; set; }
        public required int Quantite { get; set; }
        [Column(TypeName = "decimal(6,2)")]
        public required decimal PrixUnitaire { get; set;}
        
    }
}
