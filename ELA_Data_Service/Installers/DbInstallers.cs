using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ELA_Data_Service._Data.ElaDataContext;
using ELA_Data_Service.Installers.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ELA_Data_Service.Installers
{
    public class DbInstallers : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ElaDataContext>(options =>
                options.UseMySql(configuration.GetConnectionString("DataServiceConnection")));
        }
    }
}
