using Core.Models.Enums;
using DAL.Abstractions.Interfaces;
using DAL.Context;
using Entities;

namespace DAL.Repositories;

internal class GenreRepository : GenericRepository<Genre>, IGenreRepository
{
   public GenreRepository(MovieStoreContext context) : base(context)
   {
   }

   public Genre? GetByCodeAsync(GenreCode code) 
      => Context.Genres.SingleOrDefault(genre => genre.Code == (int)code);
}
