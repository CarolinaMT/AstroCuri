using AstroCuri.Shared.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AstroCuri.API.Data
{    
    //el identity permite tener una mejor gestión con los usuarios y sus role (sofía)
    public class DataContext : IdentityDbContext<User>

    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<Photography> Photographies{ get; set; }
        //Todos los indices los ponemos desde aqui

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //El campo que se va a repetir seria UserId
            //Le pone un indices al campo UserId y le decimos que es unico
            modelBuilder.Entity<User>().HasIndex(c => c.FirstName).IsUnique();
        }
    }
}
