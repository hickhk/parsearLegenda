using Microsoft.Extensions.Configuration;
using ParsearLegenda.Aplication.Domain;
using ParsearLegenda.Aplication.Infra.Interface;
using ParsearLegenda.Aplication.Service.Interface;
using System;
using System.Collections.Generic;
using System.Threading;

namespace ParsearLegenda.Aplication.Service
{
    public class ParseLegenda : IParseLegenda
    {
        private static IConfiguration _configuration;
        private static IObterLegendas _obterLegendas;
        private static IUtil _util;
        public ParseLegenda(IConfiguration configuration, IObterLegendas obterLegendas, IUtil util)
        {
            _configuration = configuration;
            _obterLegendas = obterLegendas;
            _util = util;
        }

        public void DeslocarLegendas()
        {
            string diretory = _configuration.GetSection("Files").GetSection("Path").Value;

            List<Legenda> legendas = new List<Legenda>();
            legendas = _obterLegendas.Legendas(diretory);

            foreach (var legenda in legendas)
            {
                Console.WriteLine(legenda.Frase);

                _util.InserirLinhaArquivo(diretory, legenda.Frase);

                Thread.Sleep(legenda.TempoMilesegundos);
            }
        }
    }
}