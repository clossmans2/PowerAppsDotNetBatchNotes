using FriendMusic.Models;
using Microsoft.EntityFrameworkCore;

namespace FriendMusic.Data
{
    public static class FMInitializer
    {
        public static void Initialize(IServiceProvider  serviceProvider)
        {
            using (var context = new FMContext(serviceProvider.GetRequiredService<DbContextOptions<FMContext>>())) { 
                context.Database.EnsureCreated();

                if (!context.Songs.Any())
                {
                    var songsToAdd = new Song[]
                    {
                        new Song{Artist="Alien Ant Farm", Title="Movies",Length=TimeSpan.FromSeconds(195), AlbumTitle="ANThology"},
                        new Song{Artist="Tenacious D", AlbumTitle="Tenacious D",Title="Tribute",Length=TimeSpan.FromSeconds(248)},
                        new Song{Artist="Queen", Title="Bohemian Rhapsody", AlbumTitle="A Night At The Opera", Length=TimeSpan.FromSeconds(355)},
                        new Song{Artist="Michael Jackson", Title="Thriller", Length=TimeSpan.FromSeconds(357), AlbumTitle="Thriller"}
                    };

                    var peopleToAdd = new Person[]
                    {
                        new Person{FirstName="Seth",LastName="Clossman",Birthday=DateTime.Parse("09/05/1987 02:38:00.000")},
                        new Person{FirstName="Miles",LastName="Mixon",Birthday=DateTime.Now},
                        new Person{FirstName="Dan", LastName="Pickles", Birthday=DateTime.UtcNow},
                        new Person{FirstName="Ben", LastName="Dover", Birthday = DateTime.Now},
                    };

                    context.Songs.AddRange(songsToAdd);
                    context.People.AddRange(peopleToAdd);
                    context.SaveChanges();
                }
            }
        }
    }
}
