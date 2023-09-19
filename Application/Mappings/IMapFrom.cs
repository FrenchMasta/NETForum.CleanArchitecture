﻿using AutoMapper;

namespace Application.Mappings;

// SEE: https://github.com/jasontaylordev/CleanArchitecture/blob/net7.0/src/Application/Common/Mappings/MappingProfile.cs
public interface IMapFrom<TModel>
{
    void Mapping(Profile profile) => profile.CreateMap(typeof(TModel), GetType());
}