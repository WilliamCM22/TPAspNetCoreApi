using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPAspNetCoreApi.Models;

namespace TPAspNetCoreApi.Data
{
    public class DonneesTest
    {
        public async static Task Charger(Magasin magasin)
        {
            await magasin.Database.MigrateAsync();

            if (await magasin.Article.AnyAsync())
            {
                return;
            }

            var veloDeMontagne = new Article
            {
                Nom = "Velo de montagne",
                Description = "Ce vélo en aluminium a été pensé et développé pour s'adapter au mieux à l'initiation à la randonnée par temps sec!",
                Categorie = Categorie.Velo,
                Prix = 570.00m
            };

            var veloHybride = new Article
            {
                Nom = "Velo hybride a disque",
                Description = "Vélo 9 vitesses, polyvalent, confortable et dynamique pour vos balades régulières sur piste cyclable, route et chemin.",
                Categorie = Categorie.Velo,
                Prix = 699.99m
            };

            var veloVille = new Article
            {
                Nom = "Velo de ville a cadre bas",
                Description = "Notre équipe de passionnés a conçu ce vélo pour tous vos trajets urbains.",
                Categorie = Categorie.Velo,
                Prix = 329.95m
            };

            var tente4 = new Article
            {
                Nom = "Tente de camping 4 personnes",
                Description = "Tente à arceaux pour 4 campeurs facile à monter avec deux chambres séparées et un habitacle spacieux.",
                Categorie = Categorie.Camping,
                Prix = 450.00m
            };

            var tente3 = new Article
            {
                Nom = "Tente de camping 3 personnes",
                Description = "Offrez-vous le confort : chambre spacieuse, bonne hauteur sous toit",
                Categorie = Categorie.Camping,
                Prix = 429.99m
            };

            await magasin.Article.AddRangeAsync(new Article[] { veloDeMontagne, veloHybride, veloVille, tente3, tente4 });
            await magasin.Transaction.AddRangeAsync(new Transaction[] {
            new Transaction()
            {
                Moment = new DateTime(2023,01,15),
                Article = veloDeMontagne,
                Quantite = 8,
                PrixUnitaire = 210.99m
            },

            new Transaction()
            {
                Moment = new DateTime(2023, 01, 20),
                Article = veloHybride,
                Quantite = 6,
                PrixUnitaire = 345.99m
            },

            new Transaction()
            {
                Moment = new DateTime(2023, 02, 22),
                Article = veloVille,
                Quantite = 3,
                PrixUnitaire = 159.00m
            },

            new Transaction()
            {
                Moment = new DateTime(2023, 03, 08),
                Article = tente4,
                Quantite = 11,
                PrixUnitaire = 210.00m
            },

            new Transaction()
            {
                Moment = new DateTime(2023, 03, 18),
                Article = tente3,
                Quantite = 8,
                PrixUnitaire = 210.99m
            },

            new Transaction()
            {
                Moment = new DateTime(2023, 02, 18),
                Article = veloHybride,
                Quantite = -1,
                PrixUnitaire = 699.99m
            },

            new Transaction()
            {
                Moment = new DateTime(2023, 03, 27),
                Article = tente4,
                Quantite = -1,
                PrixUnitaire = 450.00m
            }

            });

            await magasin.SaveChangesAsync();   
           
        }
    }
}
