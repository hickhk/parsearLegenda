using System;

namespace ParsearLegenda.Aplication.Domain
{
    public class Legenda
    {
        public int NumeroLinha { get; set; }
        public TimeSpan TempoInicioLegenda { get; set; }
        public TimeSpan TempoFimLegenda { get; set; }
        public int TempoMilesegundos { get; set; }
        public string Frase { get; set; }
        public string Status { get; set; }
    }
}