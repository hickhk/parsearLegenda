using ParsearLegenda.Aplication.Service.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace ParsearLegenda.Aplication.Service
{
    public class Util : IUtil
    {
        public int Inteiro(string toNormalize)
        {
            if (toNormalize.Length > 10)
                return 0;

            int resultString = 0;

            Regex regexObj = new Regex(@"[^\d]");

            if (!string.IsNullOrWhiteSpace(regexObj.Replace(toNormalize, "")))
            {
                resultString = Convert.ToInt32(regexObj.Replace(toNormalize, ""));
            }
            return resultString;
        }

        public int TempoMilesegundos(TimeSpan dataInicio, TimeSpan dataFim)
        {
            int resultado = 0;
            int inicio = 0;
            int fim = 0;
            try
            {
                inicio = (int)dataInicio.TotalMilliseconds;
                fim = (int)dataFim.TotalMilliseconds;
                resultado = fim - inicio;
            }
            catch (Exception)
            {
                throw;
            }
            return resultado;
        }

        public List<string> PegaTempoExecucao(string texto)
        {
            List<string> resultString = new List<string>();
            Regex regexObj = new Regex(@"(\d{2}[:]\d{2}[:]\d{2}[,]\d{3}).([-][-][>]).(\d{2}[:]\d{2}[:]\d{2}[,]\d{3})");

            if (regexObj.Match(texto).Success)
            {
                var grupos = regexObj.Match(texto).Groups;

                foreach (var item in grupos)
                {
                    resultString.Add(item.ToString());
                }
            }
            return resultString;
        }

        public string RetiraAspas(string texto)
        {
            string retorno = "";
            retorno = texto.Replace("\"", "");
            return retorno;
        }

        public string LimpaHtml(string valor)
        {
            string retorno = "";
            Regex rgx = new Regex(@"<\s*([^ >]+)[^>]*>.*?<\s*/\s*\1\s*>");
            retorno = rgx.Replace(valor, "");
            return retorno;
        }

        public void InserirLinhaArquivo(string diretory, string linha)
        {
            DirectoryInfo dir = new DirectoryInfo(diretory);
            FileInfo[] Files = dir.GetFiles("*.txt");

            foreach (var file in Files)
            {
                File.AppendAllText(file.FullName, linha + Environment.NewLine);
            }
        }
    }
}
