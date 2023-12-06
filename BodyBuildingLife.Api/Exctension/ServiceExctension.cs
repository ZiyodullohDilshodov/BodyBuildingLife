using BodyBuildingLife.Service.Services;
using BodyBuildingLife.Data.Repositories;
using BodyBuildingLife.Data.IRepositories;
using BodyBuildingLife.Service.Interfaces;
using BodyBuildingLife.Service.Interfaces.Card;
using BodyBuildingLife.Service.Interfaces.Person;
using BodyBuildingLife.Service.Interfaces.Protain;
using BodyBuildingLife.Service.Interfaces.Trainers;
using BodyBuildingLife.Service.Interfaces.TrainerAsset;
using BodyBuildingLife.Service.Interfaces.IPersonAsset;
using BodyBuildingLife.Service.Interfaces.PersonProtain;
using BodyBuildingLife.Service.Interfaces.PersonTrainer;
using BodyBuildingLife.Service.Interfaces.PersonStandards;
using BodyBuildingLife.Service.Services.PersonStandards;
using BodyBuildingLife.Service.Interfaces.Standards;
using BodyBuildingLife.Service.Services.Standards;

namespace BodyBuildingLife.Api.Exctension
{
    public static class ServiceExctension
    {
        public static void AddCustomerService(this IServiceCollection service)
        {
            service.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            service.AddScoped<ICardService, CardService>();
            service.AddScoped<ICardRepository, CardRepository>();

            service.AddScoped<IPersonService, PersonService>();
            service.AddScoped<IPersonRepository, PersonRepository>();

            service.AddScoped<ITrainerService,TrainerService>();
            service.AddScoped<ITrainerRepository,TrainerRepository>();

            service.AddScoped<IProteinService, ProteinService>();
            service.AddScoped<IProteinRepository, ProteinRepository>();

            service.AddScoped<IPersonAssetService, PersonAssetService>();
            service.AddScoped<IPersonAssetRepository, PersonAssetRepository>();

            service.AddScoped<ITrainerAssetService, TrainerAssetService>();
            service.AddScoped<ITrainerAssetRepository, TrainerAssetRepository>();

            service.AddScoped<IPersonAssetService, PersonAssetService>();
            service.AddScoped<IPersonProteinRepository, PersonProteinRepository>();

            service.AddScoped<IPersonProteinService,  PersonProteinService>();
            service.AddScoped<IPersonProteinRepository, PersonProteinRepository>();

            service.AddScoped<IPersonStandardRepository,PersonStandardRepository>();
            service.AddScoped<IStandardsRepository, StandardsRepository>();

            service.AddScoped<IPersonTrainerRepository, PersonTrainerRepository>();
            service.AddScoped<IPersonTrainerService, PersonTrainerService>();

            service.AddScoped<IPersonStandardsService,PersonStandardService>();
            service.AddScoped<IStandardsService, StandardsService>();


        }
    }
}
