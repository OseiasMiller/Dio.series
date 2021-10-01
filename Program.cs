using System;
using System.Collections.Generic;
using DIO.Series.Classes;

namespace DIO.Series
{
    class Program
    {
        static SerieService service = new SerieService();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                try
                {
                    Operacoes(opcaoUsuario);
                }
                catch
                {
                    Console.WriteLine("Operação Inválida. Tente novamente");
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void Operacoes(string opcaoUsuario)
        {
            switch (opcaoUsuario)
            {
                case "1":
                    ListarSeries();
                    break;
                case "2":
                    InserirSerie();
                    break;
                case "3":
                    AtualizarSerie();
                    break;
                case "4":
                    ExcluirSerie();
                    break;
                case "5":
                    VisualizarSerie();
                    break;
                case "6":
                    BuscarPorTitulo();
                    break;
                case "7":
                    ListarPorGenero();
                    break;
                case "C":
                    Console.Clear();
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static void ExcluirSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            service.Excluir(indiceSerie);
        }

        private static void VisualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = service.BuscarPorId(indiceSerie);

            Console.WriteLine(serie);
        }

        private static void AtualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int id = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            Genero entradaGenero = (Genero)int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            var retorno = service.Atualizar(id, entradaGenero, entradaTitulo, entradaDescricao, entradaAno);
            Console.WriteLine(retorno);
        }

        private static void ListarPorGenero()
        {
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            Genero entradaGenero = (Genero)int.Parse(Console.ReadLine());

            var series = service.ListaPorGenero(entradaGenero);

            LoopSeries(series);
        }

        private static void BuscarPorTitulo()
        {
            Console.WriteLine("Digite qualquer letra para procurar por titulo: ");

            string titulo = Console.ReadLine();

            var series = service.BuscarPorTitulo(titulo);

            LoopSeries(series);

        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries");
            var series = service.Lista();

            LoopSeries(series);
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            Genero entradaGenero = (Genero)int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            var retorno = service.Inserir(entradaGenero, entradaTitulo, entradaDescricao, entradaAno);
        }

        private static void LoopSeries(List<Serie> series)
        {
            foreach (var serie in series)
            {
                Console.WriteLine("------------{0}-------------", serie.Id);
                Console.WriteLine(serie);
                Console.WriteLine("-----------FIM--------------");
            }
        }


        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("--------------------------");
            Console.WriteLine("DIO Séries a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("6- Buscar por titulo");
            Console.WriteLine("7- Buscar por Genero");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine("--------------------------");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
