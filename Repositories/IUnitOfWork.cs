using KinoDotNetCore.Models;

namespace KinoDotNetCore.Repositories
{
    public interface IUnitOfWork
    {
        SeanseRepository SeanseRepository { get; }
        OpinieRepository OpinieRepository { get; }
        FilmyRepository FilmyRepository { get; }
        PracownicyRepository PracownicyRepository { get; }
        KlienciRepository KlienciRepository { get; }
        BiletyRepository BiletyRepository { get; }

        void Save();
    }
}