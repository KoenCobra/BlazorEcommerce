using Microsoft.EntityFrameworkCore;

namespace BlazorEcommerce.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Title = "The Hitchhiker's Guide to the Galaxy",
                    Description =
                        "The Hitchhiker's Guide to the Galaxy[note 1] (sometimes referred to as HG2G,[1] HHGTTG,[2] H2G2,[3] or tHGttG) is a comedy science fiction franchise created by Douglas Adams. Originally a 1978 radio comedy broadcast on BBC Radio 4, it was later adapted to other formats, including stage shows, novels, comic books, a 1981 TV series, a 1984 text-based computer game, and 2005 feature film.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/b/bd/H2G2_UK_front_cover.jpg",
                    Price = 9.99m
                },
                new Product
                {
                    Id = 2,
                    Title = "Ready Player One",
                    Description =
                        "Een dystopische toekomst in 2045. Na de Grote Recessie leeft een groot deel van de wereldbevolking in totale armoede. De hongerende mensheid vlucht weg in OASIS, een online computerspel dat door miljarden spelers tegelijkertijd gespeeld wordt. Wanneer de ontwerper van het spel, James Halliday, kinderloos sterft, blijkt deze drie sleutels, zogenaamde Easter Eggs, verstopt te hebben, welke naar een kluis met zijn erfenis leiden. Degene die de kluis vindt, wordt multimiljonair. De jonge Wade Watts gaat achter de erfenis aan en bevindt zich al snel in gevaar, zowel in de virtuele wereld als in de echte.",
                    ImageUrl =
                        "https://musicimage.xboxlive.com/catalog/video.movie.8D6KGWXP5MJH/image?locale=nl-be&mode=crop&purposes=BoxArt&q=90&h=225&w=150&format=jpg",
                    Price = 6.99m
                },
                new Product
                {
                    Id = 3,
                    Title = "1984",
                    Description =
                        "Nineteen Eighty-Four, also known as 1984, is a 1984 British dystopian science fiction film written and directed by Michael Radford, based upon George Orwell's 1949 novel of the same name. Starring John Hurt, Richard Burton, Suzanna Hamilton, and Cyril Cusack, the film follows the life of Winston Smith, a low-ranking civil servant in a war-torn London ruled by Oceania, a totalitarian superstate.[6] Smith (Hurt) struggles to maintain his sanity and his grip on reality as the regime's overwhelming power and influence persecutes individualism and individual thinking on both a political and personal level.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/c/c4/Nineteen_Eighty_Four.jpg",
                    Price = 8.99m
                });
        }

        public DbSet<Product> Products { get; set; }

    }
}
