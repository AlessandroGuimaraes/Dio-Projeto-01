using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        private static Serie novaSerie;

        public static Serie NovaSerie { get => novaSerie; set => novaSerie = value; }

        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSeries();
                        break;
                    case "3":
                        AtualizarSeries();
                        break;
                    case "4":
                        ExcluirSeries();
                        break;
                    case "5":
                        VisualizarSeries();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

               opcaoUsuario = ObterOpcaoUsuario(); 

            }  
            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();   
        }

        private static void ExcluirSerie()
        {
          Console.write("Digite o Id da Série: ");
            int indeceSerie = int.Parse(Console.ReadLine());

            repositorio.Esclui(indiceSerie); 
        }

        private static void VisualizarSerie()
        {
          Console.write("Digite o Id da Série: ");
            int indeceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);
            Console.WriteLine(serie);
        }

        private static void AtualizarSerie()
        {
            Console.write("Digite o Id da Série: ");
            int indeceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.Getvalues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero),i));
            }
            Console.Write("Digite o Genêro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Titulo da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Digite a Descrição da Série: ");
            string entradadescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie, genero: (Genero)entradaGenero,
                  titulo: entradaTitulo, ano: entradaAno, descricao: entradadescricao);

            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries");

            var Lista = repositorio.Lista();

            if(Lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach (var serie in Lista)
            {
                var excluido = sereie.retornaExcluido();
            
                Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "Excluido" :""));
            }
        }

        private static void InserirSeries()
        {
           Console.WriteLine("Inserir nova série");

           foreach (int i in Enum.GetValues(typeof(Genero)))
           {
              Console.WriteLine("Digite o Genero entre as opções acima: ");
              int entradaGenero = int.Parse(Console.ReadLine());

              Console.WriteLine("Digite o Titulo da Série: ");
              string entradaTitulo = Console.ReadLine();

              Console.WriteLine("Digite o Ano da Série: ");
              int entradaAno = int.Parse(Console.ReadLine());
              
              Console.WriteLine("Digite a Descrição da Série: ");
              string entradadescricao = Console.ReadLine();

              Serie nomaSerie = new Serie(id: repositorio.ProximoId(), genero: (Genero)entradaGenero,
                  titulo: entradaTitulo, ano: entradaAno, descricao: entradadescricao);
            
            repositorio.Insere(novaSerie);
           }
        }

        

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("..::Desafio DIO Series::..");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Lista séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
