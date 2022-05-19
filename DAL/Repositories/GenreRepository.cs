﻿using Core.Models.Enums;
using DAL.Abstractions.Interfaces;
using DAL.Context;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class GenreRepository : GenericRepository<Genre>, IGenreRepository
{
   public GenreRepository(MovieStoreContext context) : base(context)
   {
   }

   public async Task<Genre?> GetByCodeAsync(GenreCode code) 
      => await Context.Genres.SingleOrDefaultAsync(dto => dto.Code == (int)code);
}