using System.Collections.Generic;

namespace DIO.Series.Interfaces
{
    public interface IRepositorio<T>
    {
        List<T> Lista();
        List<T> ListaPorGenero(Genero genero);
        T BuscarPorId(int id);
        List<T> BuscarPorTitulo(string titulo);
        void Insere(T entidade);
        void Exclui(int id);
        void Atualiza(T entidade);


    }
}