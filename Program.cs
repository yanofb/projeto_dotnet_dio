using System;										
										
namespace DIO.Usuarios										
{										
    class Program										
    {										
        static UsuarioRepositorio repositorio = new UsuarioRepositorio();										
        static void Main(string[] args)										
        {										
            string opcaoUsuario = ObterOpcaoUsuario();										
										
			while (opcaoUsuario.ToUpper() != "X")							
			{							
				switch (opcaoUsuario)						
				{						
					case "1":					
						ListarUsuarios();				
						break;				
					case "2":					
						InserirUsuario();				
						break;				
					case "3":					
						AtualizarUsuario();				
						break;				
					case "4":					
						ExcluirUsuario();				
						break;				
					case "5":					
						VisualizarUsuario();				
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
										
        private static void ExcluirUsuario()										
		{								
			Console.Write("Digite o id da série: ");							
			int indiceUsuario = int.Parse(Console.ReadLine());							
										
			repositorio.Exclui(indiceUsuario);							
		}								
										
        private static void VisualizarUsuario()										
		{								
			Console.Write("Digite o id da série: ");							
			int indiceUsuario = int.Parse(Console.ReadLine());							
										
			var Usuario = repositorio.RetornaPorId(indiceUsuario);							
										
			Console.WriteLine(Usuario);							
		}								
										
        private static void AtualizarUsuario()										
		{								
			Console.Write("Digite o id do usuário: ");							
			int indiceUsuario = int.Parse(Console.ReadLine());							
										
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1							
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1							
			foreach (int i in Enum.GetValues(typeof(Genero)))							
			{							
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));						
			}							
			Console.Write("Digite o gênero entre as opções acima: ");							
			int entradaGenero = int.Parse(Console.ReadLine());							
										
			Console.Write("Digite o Título da Série: ");							
			string entradaTitulo = Console.ReadLine();							
										
			Console.Write("Digite o Ano de Início da Série: ");							
			int entradaAno = int.Parse(Console.ReadLine());							
										
			Console.Write("Digite a Descrição da Série: ");							
			string entradaDescricao = Console.ReadLine();							
										
			Usuario atualizaUsuario = new Usuario(id: indiceUsuario,							
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);
										
			repositorio.Atualiza(indiceUsuario, atualizaUsuario);							
		}								
        private static void ListarUsuarios()										
		{								
			Console.WriteLine("Listar séries");							
										
			var lista = repositorio.Lista();							
										
			if (lista.Count == 0)							
			{							
				Console.WriteLine("Nenhum usuário cadastrado.");						
				return;						
			}							
										
			foreach (var Usuario in lista)							
			{							
                var excluido = Usuario.retornaExcluido();										
                										
				Console.WriteLine("#ID {0}: - {1} {2}", Usuario.retornaId(), Usuario.retornaTitulo(), (excluido ? "*Excluído*" : ""));						
			}							
		}								
										
        private static void InserirUsuario()										
							
        private static string ObterOpcaoUsuario()										
		{								
			Console.WriteLine();							
			Console.WriteLine("DIO Séries a seu dispor!!!");							
			Console.WriteLine("Informe a opção desejada:");							
										
			Console.WriteLine("1- Listar usuários");							
			Console.WriteLine("2- Inserir novo usuários");							
			Console.WriteLine("3- Atualizar usuários");							
			Console.WriteLine("4- Excluir usuários");							
			Console.WriteLine("5- Visualizar usuários");							
			Console.WriteLine("C- Limpar Tela");							
			Console.WriteLine("X- Sair");							
			Console.WriteLine();							
										
			string opcaoUsuario = Console.ReadLine().ToUpper();							
			Console.WriteLine();							
			return opcaoUsuario;							
		}								
    }										
}										
										
										
										



