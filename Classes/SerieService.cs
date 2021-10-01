using System.Collections.Generic;

namespace DIO.Series.Classes
{
    public class SerieService
    {
        SerieRepositorio repo;

        public SerieService()
        {
            repo = new SerieRepositorio();
        }

        public string Inserir(Genero genero, string titulo, string descricao, int ano)
        {
            var newSerie = new Serie
            {
                Titulo = titulo,
                Descricao = descricao,
                Ano = ano,
                Genero = genero
            };

            repo.Insere(newSerie);

            return "Inserido com sucesso";
        }

        public List<Serie> Lista()
        {
            return repo.Lista();
        }

        public string Atualizar(int id, Genero genero, string titulo, string descricao, int ano)
        {
            var serie = repo.BuscarPorId(id);

            if (serie == null)
                return "Serie não encontrada";

            serie.Descricao = descricao;
            serie.Ano = ano;
            serie.Genero = genero;
            serie.Id = id;

            repo.Atualiza(serie);

            return "Atualizado com sucesso";

        }

        public string Excluir(int id)
        {
            repo.Exclui(id);
            return "Excluido com sucesso";
        }

        public Serie BuscarPorId(int id)
        {
            return repo.BuscarPorId(id);
        }

        public List<Serie> ListaPorGenero(Genero genero)
        {
            return repo.ListaPorGenero(genero);
        }

        public List<Serie> BuscarPorTitulo(string titulo)
        {
            return repo.BuscarPorTitulo(titulo);
        }

    }
}