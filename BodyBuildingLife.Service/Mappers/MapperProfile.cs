using AutoMapper;
using BodyBuildingLife.Service.DTOs.CardDTOs;
using BodyBuildingLife.Domain.Entities.Cards;
using BodyBuildingLife.Service.DTOs.PersonDTOs;
using BodyBuildingLife.Domain.Entities.Persons;
using BodyBuildingLife.Domain.Entities.Protains;
using BodyBuildingLife.Service.DTOs.Person;
using BodyBuildingLife.Service.DTOs.Standards;
using BodyBuildingLife.Domain.Entities.Assets;
using BodyBuildingLife.Domain.Entities.Trainers;
using BodyBuildingLife.Service.DTOs.ProtainDTOs;
using BodyBuildingLife.Service.DTOs.TrainerDTOs;
using BodyBuildingLife.Service.DTOs.PersonAsset;
using BodyBuildingLife.Service.DTOs.TrainerAsset;
using BodyBuildingLife.Domain.Entities.Standards;
using BodyBuildingLife.Domain.Entities.ProtainPersons;
using BodyBuildingLife.Service.DTOs.PersonProtainDTOs;
using BodyBuildingLife.Service.DTOs.PersonTrainerDTOs;
using BodyBuildingLife.Domain.Entities.PersonTreainers;
using BodyBuildingLife.Domain.Entities.PersonStandards;
using BodyBuildingLife.Service.DTOs.Card;

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
        

        CreateMap<Protein, ProteinForResultDto>().ReverseMap();
        CreateMap<Protein, ProteinForUpdateDto>().ReverseMap();
        CreateMap<Protein, ProteinForCreationDto>().ReverseMap();

        CreateMap<Trainer, TrainerForResultDto>().ReverseMap();
        CreateMap<Trainer, TrainerForUpdateDto>().ReverseMap();
        CreateMap<Trainer, TrainerForCreationDto>().ReverseMap();

        CreateMap<PersonTrainer, PersonTrainerForResultDto>().ReverseMap();
        CreateMap<PersonTrainer, PersonTrainerForUpdateDto>().ReverseMap();
        CreateMap<PersonTrainer, PersonTrainerForCreationDto>().ReverseMap();

        CreateMap<PersonProtein, PersonProteinForResultDto>().ReverseMap();
        CreateMap<PersonProtein, PersonProteinForUpdateDto>().ReverseMap();
        CreateMap<PersonProtein, PersonProteinForCreationDto>().ReverseMap();

        CreateMap<PersonAsset, PersonAssetForResultDto>().ReverseMap();
        CreateMap<TrainerAsset, TrainerAssetForResultDto>().ReverseMap();

        CreateMap<Standard, StandardForCreationDto>().ReverseMap();
        CreateMap<Standard, StandardForResultDto>().ReverseMap();
        CreateMap<Standard, StandardForUpdateDto>().ReverseMap();

        CreateMap<PersonStandard, PersonStandardForCreationDto>().ReverseMap();
        CreateMap<PersonStandard, PersonStandardForResultDto>().ReverseMap();
        CreateMap<PersonStandard, PersonStandardForUpdateDto>().ReverseMap();
        CreateMap<CardForUpdateDto, CardBlockForCreationDto>().ReverseMap();


       
    }
}
