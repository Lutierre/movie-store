using Core.Models.Enums;
using DAL.Abstractions.Interfaces;
using DAL.Context;
using DTO.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class GenreRepository : GenericRepository<GenreDto>, IGenreRepository
{
   public GenreRepository(MovieStoreContext context) : base(context)
   {
   }

   public async Task<GenreDto?> GetByCodeAsync(GenreCode code) 
      => await Context.Genres.SingleOrDefaultAsync(dto => dto.Code == (int)code);
}
