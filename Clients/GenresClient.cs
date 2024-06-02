using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients;

public class GenresClient
{
    private readonly Genre[] genres = [
        new (){
            Id= 1,
            Name= "Fighting",
        },
        new (){
            Id= 2,
            Name= "Sports",
        },
        new (){
            Id= 3,
            Name= "Moba",
        },
        new (){
            Id= 4,
            Name= "Kids & Family",
        },
        new (){
            Id= 5,
            Name= "Shooter",
        },
    ];

    public Genre[] GetGenres() => genres;
}
