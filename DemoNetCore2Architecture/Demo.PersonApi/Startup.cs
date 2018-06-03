using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.PersonApi.DataContexts;
using Demo.PersonApi.Repositories;
using Demo.PersonApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Demo.PersonApi.Models;
using Demo.PersonApi.Repositories.Interfaces;
using FluentValidation;
using Demo.PersonApi.Validation;

namespace Demo.PersonApi
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
            services.AddMvc().AddJsonOptions(options => {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();
            });

            var cc = Configuration.GetSection("ConnectionStrings").GetValue<string>("DefaultConnection");
            services.AddDbContext<SchoolContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            Bootstrapper(services);
        }

        private void Bootstrapper(IServiceCollection services){
            services.AddTransient<IPersonService,PersonService>();
            services.AddTransient<IValidator<Person>, PersonValidator>();
            //services.AddTransient<IPersonServiceAsync,PersonServiceAsync>();
            services.AddScoped<IPersonRepository,PersonRepository>();
            //services.AddScoped<ISchoolUnitOfWork,SchoolUnitOfWork>();
            services.AddScoped<ICourseRepository,CourseRepository>();
            services.AddScoped<IPersonRepositoryAsync,PersonRepositoryAsync>();
            //services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            //services.AddScoped<IPersonRepositoryGeneric,PersonRepositoryGeneric>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
