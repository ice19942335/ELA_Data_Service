using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ELA_Data_Service.Installers.Interfaces;
using ELA_Data_Service.Services.Implementation;
using ELA_Data_Service.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ELA_Data_Service.Installers
{
    public class ServicesInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            //Transient
            services.AddTransient<ITasksService, TasksService>();
            services.AddTransient<IUserService, UserService>();
        }
    }
}
