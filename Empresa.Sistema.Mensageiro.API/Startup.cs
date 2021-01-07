using System;
using Empresa.Sistema.Cadastro.Application.Mapping;
using Empresa.Sistema.Cadastro.Infra.Data;
using Empresa.Sistema.Cadastro.Infra.IoC;
using Empresa.Sistema.Infra.Shared.Domain;
using Empresa.Sistema.Infra.Shared.Logging;
using Infra.Logging.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using AutoMapper;
using System.IO;

namespace Empresa.Sistema.Mensageiro.API
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
            #region Injeção de dependencia

            //Configurando a injeção de dependencias dos services
            ConfigureService.ConfigureDependenciesServices(services);

            //Configurando a injeção de dependencias dos repositórios
            ConfigureRepository.ConfigureDependenciesRepository(services);

            #endregion

            #region Configurar AutoMapper

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ParametroSistemaProfile());
                cfg.AddProfile(new TipoParametroSistemaProfile());
                cfg.AddProfile(new PetStoreProfile());
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            #endregion

            #region Configurando DapperExtensions

            RegisterMappings.Register();

            #endregion

            #region Log

            services.AddSingleton(typeof(ILogFacede), typeof(LogFacede));

            #endregion

            #region configurando uso do IIS

            //services.Configure<IISOptions>(options =>
            //{
            //    options.AutomaticAuthentication = false;
            //    options.ForwardClientCertificate = false;
            //});

            #endregion

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<AuthenticatedUser>();

            //services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_2);
            services.AddControllers();

            #region Configurando Swagger

            #region .NetCore 2.2
            ////Adicionando Swagger
            //services.AddSwaggerGen(c => {
            //    //c.CustomSchemaIds(t =>/ t.FullName);
            //    c.SwaggerDoc("v1",
            //        new Info
            //        {
            //            Title = "Empresa.Sistema - Parâmetros do Sistema",
            //            Version = "v1",
            //            Description = "API REST criada com o ASP.NET Core 2.2 para manter os parâmetros do sistema",
            //            Contact = new Contact
            //            {
            //                Name = "Carlos Rodrigues",
            //                Url = "https://github.com/rodriguescarlos"
            //            }
            //        });
            //});
            #endregion

            //Adicionando Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API com AspNetCore 3.1",
                    Description = "Arquitetura DDD",
                    TermsOfService = new Uri("https://github.com/rodriguescarlos"),
                    Contact = new OpenApiContact
                    {
                        Name = "Carlos Rodrigues",
                        Email = "rodrigues.carlos@gmail.com",
                        Url = new Uri("https://github.com/rodriguescarlos")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Termo de Licença de Uso",
                        Url = new Uri("https://github.com/rodriguescarlos")
                    }
                });

                //c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                //{
                //    Description = "Entre com o Token JWT",
                //    Name = "Authorization",
                //    In = ParameterLocation.Header,
                //    Type = SecuritySchemeType.ApiKey
                //});

                //c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                //{
                //    new OpenApiSecurityScheme {
                //        Reference = new OpenApiReference {
                //            Id="Bearer",
                //            Type=ReferenceType.SecurityScheme
                //        }
                //    },
                //    new List<string>()
                //}
               //});
            });

            #endregion



        }

        #region NetCore 3.1

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
        

            //Configurando o Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                string swaggerJsonBasePath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..";
                c.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "Empresa.Sistema - Parâmetros do Sistema V1 - .NetCore 3.1");

                //c.SwaggerEndpoint("/swagger/v1/swagger.json", "Empresa.Sistema - Parâmetros do Sistema V1 - .NetCore 3.1");
                //c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        #endregion

        #region NetCore 2.2
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        //{
        //    //loggerFactory.AddLog4Net();

        //    if (env.IsDevelopment())
        //    {
        //        app.UseDeveloperExceptionPage();
        //    }

        //    // Ativando middlewares para uso do Swagger
        //    //app.UseSwagger(x => x.RouteTemplate = "api-docs/{documentName}/swagger.json");

        //    app.UseSwagger();
        //    app.UseSwaggerUI(c => {

        //        //c.RoutePrefix = "api-docs";

        //        string swaggerJsonBasePath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..";
        //        c.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "Empresa.Sistema - Parâmetros do Sistema V1");

        //        //c.SwaggerEndpoint("/swagger/v1/swagger.json", "Empresa.Sistema - Parâmetros do Sistema V1");
        //    });

        //    app.UseMvc();
        //}

        #endregion

    }
}
