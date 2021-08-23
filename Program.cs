using System;

namespace Dio.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
           string opcaoUsuario = ObterOpcaoUsuario();

           while(opcaoUsuario.ToUpper() != "X")
           {
               switch(opcaoUsuario)
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
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
               }

               opcaoUsuario = ObterOpcaoUsuario();
           }

           Console.WriteLine("Obrigado por utilizar nossos servicos");
           Console.ReadLine();
        }

        private static void ExcluirSerie(){
            Console.WriteLine("Digite o id da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }

        private static void VisualizarSerie(){
            Console.WriteLine("Digite o id da serie:");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.Write(serie);
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar Series");

            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma serie encontrada.");
                return;
            }

            foreach(var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                if(!excluido){
                    Console.WriteLine("#DIO {0}: - {1}", serie.retornaId(), serie.retornaTitulo());
                }
                
            }
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o id da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());


            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i , Enum.GetName(typeof(Genero), i));
            }

            Console.WriteLine("Digite o genero entre as opcoes acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o titulo da serie: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de inicio da serie: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descricao da serie: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizarSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero, 
                                        titulo: entradaTitulo, 
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Atualiza(indiceSerie, atualizarSerie);

        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir Series");

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
            Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
                
            }

            Console.Write("Digite o genero entre as opcoes acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o titulo da serie: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de inicio da serie: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descricao da serie: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero, 
                                        titulo: entradaTitulo, 
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.insere(novaSerie);
            
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Series a seu dispor!!!");
            Console.WriteLine("Informe a opcao desejada:");
            Console.WriteLine("1- Listar series");
            Console.WriteLine("2- Inserir serie");
            Console.WriteLine("3- Atualizar serie");
            Console.WriteLine("4- Excluir serie");
            Console.WriteLine("5- Visualizar serie");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");


            string opcaoUsuario = Console.ReadLine().ToUpper();    
            Console.WriteLine();
            

            return opcaoUsuario;
        }
    }
}
