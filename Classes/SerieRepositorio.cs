using System.Collections.Generic;
using System.Linq;
using DIO.Series.Interfaces;

namespace DIO.Series.Classes
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private int geradorId = 1;
        private List<Serie> series = new List<Serie>();

        public void Atualiza(Serie entidade)
        {
            var index = series.FindIndex(x => x.Id == entidade.Id);
            if (index > 0)
                series[index] = entidade;
        }

        public Serie BuscarPorId(int id)
        {
            return series.Where(x => x.Id == id).First();
        }

        public List<Serie> BuscarPorTitulo(string titulo)
        {
            return series.Where(x => x.Titulo.ToLower().Contains(titulo.ToLower())).ToList();
        }

        public void Exclui(int id)
        {
            var serie = BuscarPorId(id);

            series.Remove(serie);
        }

        public void Insere(Serie entidade)
        {
            entidade.Id = ProximoId();
            series.Add(entidade);
        }

        public List<Serie> Lista()
        {
            return series;
        }

        public List<Serie> ListaPorGenero(Genero genero)
        {
            return series.Where(x => x.Genero == genero).ToList();
        }

        private int ProximoId()
        {
            return geradorId++;
        }
    }
}