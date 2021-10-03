using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ParsearLegenda.Aplication.Domain;
using ParsearLegenda.Aplication.Infra.Interface;
using ParsearLegenda.Aplication.Service;
using ParsearLegenda.Aplication.Service.Interface;

namespace ParsearLegenda.Aplication.Infra.Ioc
{
    public static class DependenciInjection
    {
        public static IServiceCollection InserirDependencia(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConfiguration>(configuration);
            services.AddTransient<IObterLegendas, ObterLegendas>();
            services.AddTransient<IParseLegenda, ParseLegenda>();
            services.AddTransient<IUtil, Util>();
            services.BuildServiceProvider();
            return services;
        }
    }
}