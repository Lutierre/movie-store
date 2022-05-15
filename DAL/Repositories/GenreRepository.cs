using Core.Models.Enums;
using DAL.Context;
using DTO.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class GenreRepository : GenericRepository<GenreDto>
{
   public GenreRepository(MovieStoreContext context) : base(context)
   {
   }

   public async Task<GenreDto?> GetByCodeAsync(GenreCode code) 
      => await _context.Genres.SingleOrDefaultAsync(dto => dto.Code == (int)code);
}
