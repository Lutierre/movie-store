﻿using AutoMapper;
using Core.Models.Enums;
using Entities;

namespace BLL.Automapper.ModelConverters;

internal class GenreDtoModelConverter : ITypeConverter<Genre, GenreCode>
{
    public GenreCode Convert(Genre source, GenreCode destination, ResolutionContext context) 
        => (GenreCode)source.Code;
}
