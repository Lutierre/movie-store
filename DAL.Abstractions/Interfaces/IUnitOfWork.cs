using Entities;

namespace DAL.Abstractions.Interfaces;

public interface IUnitOfWork
{
    IRepository<Comment> CommentRepository { get; }
    
    IRepository<Director> DirectorRepository { get; }

    IRepository<Movie> MovieRepository { get; }

    IGenreRepository GenreRepository { get; }

    Task SaveAsync();

    IRepository<T> GetRepository<T>() where T : BaseEntity;
}


