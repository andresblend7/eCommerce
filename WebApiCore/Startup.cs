using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebApiCore.DataAccess;
using WebApiCore.DataAccess.Mapper;
using WebApiCore.DataAccess.Models;
using WebApiCore.DataAccess.Vault;

namespace WebApiCore
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
            //Añadimos el contexto de la base de datos
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection"))
            );

            //Inyectamos los ModelStructures
            services.AddScoped<ICoreModel, CoreModel>();


            //Se utiliza la configuración del DataAccess/Mapper/ProfileConfig
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            //Se crea el mapper
            IMapper mapper = mappingConfig.CreateMapper();

            //Inyectamos el mapper en la memoria
            services.AddSingleton(mapper);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2).
                AddJsonOptions(options=> options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, AppDbContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            //Confirmamos que la base tiene los datos iniciales necesarios
            this.InitDatabase(dbContext);

        }

        /// <summary>
        /// Método encargado de inicializar los valores base en la DB
        /// </summary>
        /// <param name="dbContext"></param>
        private void InitDatabase(AppDbContext dbContext)
        {
            #region Rol
            //Obtenemos los roles creados
            var entity = dbContext.Dic_Rol.FirstOrDefault();

            //Se crean los roles si no existe ninguno en la DB
            if (entity == null) {
                dbContext.Dic_Rol.AddRange(RolValut.GetRoles());
                dbContext.SaveChanges();
            }
            #endregion

            #region Cities
            //Obtenemos las ciudades creadas.
            var cities = dbContext.Dic_Cities.FirstOrDefault();

            //Se crean las ciudades si no existe ninguna en la DB
            if (cities == null) {
                dbContext.Dic_Cities.AddRange(CitiesVault.GetCities());
                dbContext.SaveChanges();
            }
            #endregion

            #region users

            var users = dbContext.Dic_Users.FirstOrDefault();

            if (users == null) {
                dbContext.Dic_Users.AddRange(UsersVault.GetBasicUsers());
                dbContext.SaveChanges();
            }

            #endregion

        }
    }
}
