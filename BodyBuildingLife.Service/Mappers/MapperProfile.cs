using AutoMapper;
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
using BodyBuildingLife.Service.DTOs.Person;
using BodyBuildingLife.Domain.Entities.Assets;
using BodyBuildingLife.Service.DTOs.PersonAsset;
using BodyBuildingLife.Service.DTOs.TrainerAsset;

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

        CreateMap<PersonProtein, PersonProtainForResultDto>().ReverseMap();
        CreateMap<PersonProtein, PersonProtainForUpdateDto>().ReverseMap();
        CreateMap<PersonProtein, PersonProtainForCreationDto>().ReverseMap();

        CreateMap<PersonAsset, PersonAssetForResultDto>().ReverseMap();
        CreateMap<TrainerAsset, TrainerAssetForResultDto>().ReverseMap();

    }
}
