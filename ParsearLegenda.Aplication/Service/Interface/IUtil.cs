using System;
using System.Collections.Generic;

namespace ParsearLegenda.Aplication.Service.Interface
{
    public interface IUtil
    {
        public int Inteiro(string toNormalize);
        public List<string> PegaTempoExecucao(string texto);
        public string RetiraAspas(string texto);
        public int TempoMilesegundos(TimeSpan dataInicio, TimeSpan dataFim);
        public string LimpaHtml(string valor);
        public void InserirLinhaArquivo(string diretory, string linha);
    }
}
