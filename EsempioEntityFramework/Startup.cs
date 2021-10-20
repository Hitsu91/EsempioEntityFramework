using EsempioEntityFramework.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EsempioEntityFramework.Data;

namespace EsempioEntityFramework
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Questa configurazione fa in modo di abilitare 
            // l'EF con il database in memoria di prova!
            services.AddDbContext<DataContext>(
                opt => opt.UseInMemoryDatabase("SuperHeroes")
            );
            // Aggiungo alle dependencies le nostro classi Services
            // In modo che poi nel controller saremo in grado di farci
            // fornire attraverso la DI, un oggetto (Singleton) dell'interfaccia
            // dichiarata come Primo Generico e l'implementazione del Secondo Generico
            services.AddScoped<ISuperEroeService, SuperEroeService>();
            // I services che fanno utilizzo del DataContext non devono essere aggiunti
            // sottoforma di Singleton, ma Scoped
            // Altrimenti il Framework andrà in eccezione, dato che non può fornire
            // alla creazione di un Singleton un oggetto (DataContext) che sua volta 
            // non viene creato come Singleton, ma come Scoped
            // Scoped a differenza di Singleton, verrà creato nel momento del bisogno
            // ma potrebberò esistere più istanze di questo oggetto
            // Ma a noi va benissimo così, per EF non lavora su un DAO singleton
            // ANZI, ne crea tanti quante poi sono le richieste
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
