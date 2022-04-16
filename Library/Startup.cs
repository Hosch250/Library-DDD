using AutoMapper;
using FluentValidation;
using Library.Application;
using Library.Domain;
using Library.Domain.Entities.Book;
using Library.Domain.Entities.User.Factories;
using Library.GraphQL;
using Library.Infrastructure.Configuration;
using Library.Infrastructure.Storage;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using System.Linq;
using System.Reflection;

namespace Library
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Library", Version = "v1" });
            });

            services.AddOptions<FeatureFlags>().Configure<IConfiguration>((settings, config) => config.GetSection("FeatureFlags").Bind(settings));

            services.AddTransient<LibraryContext>();
            services.AddTransient<ILibraryRepository, LibraryRepository>();
            services.AddTransient<IUserApplication, UserApplication>();
            services.AddTransient<IBookApplication, BookApplication>();
            services.AddTransient<UserFactory>();

            Assembly.GetExecutingAssembly().GetTypes()
                .Where(w => w.BaseType is { IsGenericType: true } &&
                    w.BaseType.GetGenericTypeDefinition() == typeof(AbstractValidator<>))
                .ToList()
                .ForEach(f => services.AddTransient(f));

            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            MongoDefaults.GuidRepresentation = MongoDB.Bson.GuidRepresentation.Standard;

            services.AddSingleton(sp =>
            {
                return sp.GetRequiredService<LibraryContext>().BookDto;
            });

            services.AddSingleton(sp =>
            {
                return sp.GetRequiredService<LibraryContext>().UserDto;
            });

            services.AddScoped<Query>();
            services.AddSingleton(
            services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddMongoDbFiltering()
                .AddMongoDbSorting()
                .AddMongoDbProjections()
                .AddMongoDbPagingProviders());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Library v1"));
            }

            app.UseHttpsRedirection();

            app.UseCors(a => {
                a.AllowAnyOrigin();
                a.AllowAnyHeader();
                a.AllowAnyMethod();
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllers();
                endpoints.MapGraphQL();
                endpoints.MapBananaCakePop();
            });

            var serviceProvider = app.ApplicationServices;
            DomainEvents.Publisher = () => serviceProvider.GetRequiredService<IPublisher>();
        }
    }
}
