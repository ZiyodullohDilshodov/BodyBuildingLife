﻿using AutoMapper;
using BodyBuildingLife.Service.DTOs.CardDTOs;
using BodyBuildingLife.Domain.Entities.Cards;
using BodyBuildingLife.Service.DTOs.PersonDTOs;
using BodyBuildingLife.Domain.Entities.Persons;
using BodyBuildingLife.Domain.Entities.Protains;
using BodyBuildingLife.Domain.Entities.Trainers;
using BodyBuildingLife.Service.DTOs.ProtainDTOs;
using BodyBuildingLife.Service.DTOs.TrainerDTOs;
using BodyBuildingLife.Domain.Entities.ProtainPersons;
using BodyBuildingLife.Service.DTOs.PersonProtainDTOs;
using BodyBuildingLife.Service.DTOs.PersonTrainerDTOs;
using BodyBuildingLife.Domain.Entities.PersonTreainers;

namespace BodyBuildingLife.Service.Mappers;

public  class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Card,CardForResultDto>().ReverseMap();
        CreateMap<Card,CardForUpdateDto>().ReverseMap();
        CreateMap<Card,CardForCreationDto>().ReverseMap();

        CreateMap<Person,PersonForResultDto>().ReverseMap();
        CreateMap<Person,PersonForUpdateDto>().ReverseMap();
        CreateMap<Person,PersonForCreationDto>().ReverseMap();

        CreateMap<Protain, ProtainForResultDto>().ReverseMap();
        CreateMap<Protain, ProtainForUpdateDto>().ReverseMap();
        CreateMap<Protain, ProtainForCreationDto>().ReverseMap();

        CreateMap<Trainer, TrainerForResultDto>().ReverseMap();
        CreateMap<Trainer, TrainerForUpdateDto>().ReverseMap();
        CreateMap<Trainer, TrainerForCreationDto>().ReverseMap();

        CreateMap<PersonTrainer, PersonTrainerForResultDto>().ReverseMap();
        CreateMap<PersonTrainer, PersonTrainerForUpdateDto>().ReverseMap();
        CreateMap<PersonTrainer, PersonTrainerForCreationDto>().ReverseMap();

        CreateMap<PersonProtain, PersonProtainForResultDto>().ReverseMap();
        CreateMap<PersonProtain, PersonProtainForUpdateDto>().ReverseMap();
        CreateMap<PersonProtain, PersonProtainForCreationDto>().ReverseMap();

    }
}