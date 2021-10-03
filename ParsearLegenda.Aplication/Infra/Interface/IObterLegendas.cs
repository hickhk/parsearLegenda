using ParsearLegenda.Aplication.Domain;
using System.Collections.Generic;

namespace ParsearLegenda.Aplication.Infra.Interface
{
    public interface IObterLegendas
    {
        public List<Legenda> Legendas(string diretory);
    }
}
