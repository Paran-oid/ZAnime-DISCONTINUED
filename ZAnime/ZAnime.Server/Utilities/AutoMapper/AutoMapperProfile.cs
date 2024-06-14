﻿using AutoMapper;
using Zanime.Server.Models.Main;
using Zanime.Server.Models.Main.DTO.Actor_Model;
using Zanime.Server.Models.Main.DTO.Anime_Model;
using Zanime.Server.Models.Main.DTO.Character_Model;
using Zanime.Server.Models.Main.DTO.Comment_Model;

namespace Zanime.Server.Utilities.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //ACTOR
            CreateMap<ActorVM, Actor>();

            //CHARACTER
            CreateMap<CharacterVM, Character>();

            //ANIME
            CreateMap<AnimeVM, Anime>();
            CreateMap<Anime, AnimeVM>();

            //COMMENT
            CreateMap<Comment, CommentAnimeVM>();
        }
    }
}