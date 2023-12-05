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
using BodyBuildingLife.Domain.Entities.Standards;
using BodyBuildingLife.Service.DTOs.Standards;

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
        CreateMap<Person,PersonForAddProteinDto>().ReverseMap();
       

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

        CreateMap<ProteinStandards, ProteinForCreationDto>().ReverseMap();
        CreateMap<ProteinStandards, ProteinForResultDto>().ReverseMap();

        CreateMap<ProteinStandards, ProteinStandardsForCreationDto>().ReverseMap();
        CreateMap<ProteinStandards, ProteinStandardsForResultDto>().ReverseMap();
    }
}
