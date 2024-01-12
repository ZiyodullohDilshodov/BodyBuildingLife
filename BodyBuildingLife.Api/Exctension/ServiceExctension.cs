using System.Text;
using System.Reflection;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;
using BodyBuildingLife.Service.Services;
using BodyBuildingLife.Data.Repositories;
using BodyBuildingLife.Data.IRepositories;
using BodyBuildingLife.Service.Interfaces.Card;
using BodyBuildingLife.Service.Interfaces.Person;
using BodyBuildingLife.Service.Services.Standards;
using BodyBuildingLife.Service.Interfaces.Protain;
using BodyBuildingLife.Service.Interfaces.Trainers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using BodyBuildingLife.Service.Interfaces.Standards;
using BodyBuildingLife.Service.Interfaces.IPersonAsset;
using BodyBuildingLife.Service.Interfaces.TrainerAsset;
using BodyBuildingLife.Service.Interfaces.PersonProtain;
using BodyBuildingLife.Service.Services.PersonStandards;
using BodyBuildingLife.Service.Interfaces.PersonTrainer;
using BodyBuildingLife.Service.Interfaces.PersonStandards;
using BodyBuildingLife.Service.Interfaces.PaymentOfCardBalanses;
using BodyBuildingLife.Service.Services.PaymentOfCardBalanses;

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

            service.AddScoped<IPaymentOfCardBalansService,PaymentOfCardBalansService>();


        }


        public static void AddJwtService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
                    ClockSkew = TimeSpan.Zero
                };
            });
        }

        public static void AddSwaggerService(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Shamsheer.Api", Version = "v1" });
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description =
                        "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[]{ }
            }
        });
            });
        }
    }
}
