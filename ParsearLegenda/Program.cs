using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ParsearLegenda.Aplication.Infra.Ioc;
using ParsearLegenda.Aplication.Service.Interface;
using System;
using System.IO;

namespace ParsearLegenda
{
    internal class Program
    {
        public IConfiguration Configuration { get; }

        private static IParseLegenda _parseLegenda;

        private static void Main(string[] args)
        {

            bool showMenu = true;
            showMenu = MenuPrincipal();

        }

        private static bool MenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("Obs: O diretório do arquivo de legenda e do arquivo txt para salvar as legendas");
            Console.WriteLine("está configurado no arquivo appsettings.json chave: Files -> Path");
            Console.WriteLine("\r\n");
            Console.WriteLine("*************************MENU*************************************");
            Console.WriteLine("\r\n");
            Console.WriteLine("1) INICIAR PROCESSO DE LEGENDAS POR PALAVRAS");
            Console.WriteLine("2) Sair");
            Console.WriteLine("\r\n");
            Console.WriteLine("******************************************************************");

            Console.WriteLine("SELECIONE UMA OPÇÃO:");
            string option = Console.ReadLine();

            if (option.Equals("2"))
                return false;

            IniciarProcesso();
            return true;

        }

        public static void IniciarProcesso()
        {

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            var configuration = builder.Build();

            var services = DependenciInjection.InserirDependencia(new ServiceCollection(), configuration);

            ServiceProvider serviceProvider = services.BuildServiceProvider();

            _parseLegenda = serviceProvider.GetService<IParseLegenda>();

            _parseLegenda.DeslocarLegendas();

        }
    }
}