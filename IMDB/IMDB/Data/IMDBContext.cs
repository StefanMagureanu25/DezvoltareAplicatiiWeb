using IMDB.Models;
using IMDB.Models.AssociativeModels;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Data
{
    public class IMDBContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet <Director> Directors { get; set; } 
        public DbSet <UserSettings> UserSettings { get; set; }
        public DbSet <MovieGenre> MovieGenres { get; set; }
        public IMDBContext(DbContextOptions<IMDBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //primary keys 
            modelBuilder.Entity<User>()
                .HasKey(u => u.UserId);

            modelBuilder.Entity<Director>()
                .HasKey(d => d.DirectorId);

            modelBuilder.Entity<Genre>()
                .HasKey(g => g.GenreId);

            modelBuilder.Entity<Movie>()
                .HasKey(m => m.MovieId);

            modelBuilder.Entity<UserSettings>()
                .HasKey(us => us.UserSettingsId);

            //one to one (User <-> UserSettings)
            modelBuilder.Entity<User>()
                .HasOne(u => u.UserSettings)
                .WithOne(us => us.User)
                .HasForeignKey<UserSettings>(us => us.UserId);

            //one to many (Director <-> Movie)
            modelBuilder.Entity<Director>().
                HasMany(d => d.Movies).
                WithOne(m => m.Director)
                .HasForeignKey(m => m.DirectorId);

            //one to many (Director <-> User)
            modelBuilder.Entity<Director>().
                HasMany(d => d.Users).
                WithOne(u => u.FavouriteDirector)
                .HasForeignKey(u => u.DirectorId);

            //many to many (Genre <-> Movie)
            modelBuilder.Entity<MovieGenre>().
                HasKey(k => new { k.MovieId, k.GenreId });

            modelBuilder.Entity<MovieGenre>().
                HasOne(mg => mg.Movie).
                WithMany(m => m.MovieGenre)
                .HasForeignKey(mg => mg.MovieId);

            modelBuilder.Entity<MovieGenre>().
                HasOne(mg => mg.Genre).
                WithMany(g => g.MovieGenre)
                .HasForeignKey(mg => mg.GenreId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
