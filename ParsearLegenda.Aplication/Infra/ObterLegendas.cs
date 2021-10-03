using ParsearLegenda.Aplication.Infra.Interface;
using ParsearLegenda.Aplication.Service.Interface;
using System;
using System.Collections.Generic;
using System.IO;

namespace ParsearLegenda.Aplication.Domain
{
    public class ObterLegendas : IObterLegendas
    {
        private static IUtil _util;
        public ObterLegendas(IUtil util)
        {
            _util = util;
        }

        public List<Legenda> Legendas(string diretory)
        {
            String line;
            List<Legenda> legendas = new List<Legenda>();
            Legenda legenda = new Legenda();

            try
            {
                DirectoryInfo dir = new DirectoryInfo(diretory);
                FileInfo[] Files = dir.GetFiles("*.srt");

                foreach (FileInfo file in Files)
                {
                    string path = file.FullName;

                    StreamReader sr = new StreamReader(path);

                    line = sr.ReadLine();

                    while (line != null)
                    {
                        if (_util.Inteiro(line) != 0)
                        {
                            legenda.NumeroLinha = _util.Inteiro(line);
                        }
                        else if (line.Contains("-->"))
                        {
                            List<string> retornoTempo = _util.PegaTempoExecucao(line);
                            legenda.TempoInicioLegenda = TimeSpan.Parse(retornoTempo[1]);
                            legenda.TempoFimLegenda = TimeSpan.Parse(retornoTempo[3]);
                            legenda.TempoMilesegundos = _util.TempoMilesegundos(legenda.TempoInicioLegenda, legenda.TempoFimLegenda);
                        }
                        else if (!string.IsNullOrEmpty(line))
                        {
                            legenda.Frase += _util.RetiraAspas(_util.LimpaHtml(line)) + " ";
                        }
                        else if (string.IsNullOrEmpty(line))
                        {
                            legenda.Status = "Legenda Recuperada";
                            legendas.Add(legenda);
                            legenda = new Legenda();
                        }
                        line = sr.ReadLine();
                    }
                    sr.Close();
                }
            }
            catch (Exception e)
            {
                legenda.Status = "Erro ao recuperar a legenda";
                legendas.Add(legenda);
            }
            finally
            {

            }
            return legendas;
        }
    }
}