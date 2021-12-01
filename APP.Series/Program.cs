using System;

namespace APP.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
        
            string opcaoEscolhida = ObterOpcaoUsuario();
            while(opcaoEscolhida.ToUpper() != "X")
            {
                switch (opcaoEscolhida)
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
                    case "C": 
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoEscolhida = ObterOpcaoUsuario();
            }  
        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("*****Visualizar Série*****");
            Console.Write("Digite o ID da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            if(!repositorio.VerificaExistenciaSerie(indiceSerie)){
                Console.WriteLine("Nenhuma Série encontrada para o ID informado! Digite um ID Válido!");
                return;
            }

            Console.WriteLine(repositorio.RetornarPorId(indiceSerie));
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("*****Excluir Série*****");
            Console.Write("Digite o ID da Série para Exclusão: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            if(!repositorio.VerificaExistenciaSerie(indiceSerie)){
                Console.WriteLine("Nenhuma Série encontrada para o ID informado! Digite um ID Válido!");
                return;
            }

            repositorio.Excluir(indiceSerie);
        }

        static void SolicitarDadosSerie(out int entradaGenero, out string entradaTitulo, out int entradaAno, out string entradaDescricao){
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o Gênero entre as Opções Acima: ");
            entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            entradaDescricao = Console.ReadLine();
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("*****Atualizar Série*****");
            Console.Write("Digite o ID da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            if(!repositorio.VerificaExistenciaSerie(indiceSerie)){
                Console.WriteLine("Nenhuma Série encontrada para o ID informado! Digite um ID Válido!");
                return;
            }
            
            //SolicitarDadosSerie();
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o Gênero entre as Opções Acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(indiceSerie, (Genero)entradaGenero, entradaTitulo, entradaDescricao, entradaAno);
            
            repositorio.Atualizar(indiceSerie, atualizaSerie);
        }

        private static void InserirSerie()
        {
            Console.WriteLine("*****Inserir Nova Série*****");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o Gênero entre as Opções Acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(repositorio.ProximoId(), (Genero)entradaGenero, entradaTitulo, entradaDescricao, entradaAno);
            
            repositorio.Inserir(novaSerie);
        }

        private static void ListarSeries()
        {
            Console.WriteLine("*****Listar Séries****");
            var lista = repositorio.Listar();
            if(lista.Count == 0){
                Console.WriteLine("Nenhuma série cadastrada!");
                return;
            }

            foreach (var serie in lista)
            {
                bool excluido = serie.RetornarExcluido();
                Console.WriteLine("#ID: {0} - Titulo: {1}  {2}", serie.RetornaId(), serie.RetornaTitulo(), (excluido ? "-> *Excluído*" : ""));
            }
        }

        public static string ObterOpcaoUsuario(){
            Console.WriteLine();
            Console.WriteLine("APP Séries ao seu dispor!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Listar Séries");
            Console.WriteLine("2 - Inserir Nova Série");
            Console.WriteLine("3 - Atualizar Série");
            Console.WriteLine("4 - Excluir Série");
            Console.WriteLine("5 - Visualizar Série");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();
            
            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
