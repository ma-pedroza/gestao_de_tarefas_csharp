using Projeto03_Gestao_De_Tarefas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto03_Gestao_De_Tarefas
{
    static class Funcoes
    {
        private static Tarefa.Status statusEnum;
        private static Tarefa.Prioridade prioridadeEnum;

        public static Responsavel instanciarResponsavel()
        {
            Console.WriteLine("");
            Console.Write("Digite o nome do responsável: ");
            string nome = Console.ReadLine();

            while (nome == "" || nome == null)
            {
                Console.WriteLine();
                Console.WriteLine("Nome de Responsável inválido. Digite ao menos um caracter");
                Console.Write("Digite novamente o nome do responsável: ");
                nome = Console.ReadLine();
            }

            Console.Write("Digite o email: ");
            string email = Console.ReadLine();

            while (email.IndexOf("@") == -1)
            {
                Console.WriteLine();
                Console.WriteLine("Você digitou um Email inválido. Deve conter um '@'");
                Console.Write("Digite novamente um email: ");
                email = Console.ReadLine();
            }

            foreach(Responsavel item in Listas.ListadeResponsavel)
            {
                while(email == item.Email)
                {
                    Console.WriteLine();
                    Console.WriteLine("Email já existente. Por favor insira outro Email");
                    Console.Write("Digite novamente um email: ");
                    email = Console.ReadLine();
                }
            }


            Responsavel objeto = new Responsavel(nome, email);
            return objeto;
        }

        public static Tarefa instanciarTarefa()
        {
            Console.WriteLine("");
            Console.Write("Digite o título da tarefa: ");
            string titulo = Console.ReadLine();

            while (titulo == "" || titulo == null) {
                Console.WriteLine();
                Console.WriteLine("Título inválido. Digite ao menos um caracter");
                Console.Write("Digite o título da tarefa: ");
                titulo = Console.ReadLine();
            }

            Console.Write("Digite a data limite - (formato dd/mm/yyyy): ");
            string dataTexto = Console.ReadLine();
            DateOnly data;

            while (!DateOnly.TryParse(dataTexto, out data))
            {
                Console.WriteLine();
                Console.WriteLine("Data inválida. Por favor digite uma data válida - Necessário conter '/' ");
                Console.Write("Formato - dd/mm/yyyy : ");
                dataTexto = Console.ReadLine();
            }

            DateOnly hoje = DateOnly.FromDateTime(DateTime.Now);

            while(data < hoje)
            {
                Console.WriteLine();
                Console.WriteLine("A Data não pode ser menor que a Data atual.");
                Console.Write("Digite a data limite - (formato dd/mm/yyyy): ");
                dataTexto = Console.ReadLine();
                while (!DateOnly.TryParse(dataTexto, out data))
                {
                    Console.WriteLine();
                    Console.WriteLine("Data inválida. Por favor digite uma data válida - Necessário conter '/' ");
                    Console.Write("Formato - dd/mm/yyyy : ");
                    dataTexto = Console.ReadLine();
                }
            }


            Console.Write("Digite o status da tarefa - (Fazer - Andamento - Concluido): ");
            string status = Console.ReadLine();

            while (!Enum.TryParse(status, true, out Tarefa.Status statusEnum))
            {
                Console.WriteLine();
                Console.WriteLine("Digite uma opção válida.");
                Console.WriteLine();
                Console.Write("Digite o status da tarefa - (Fazer - Andamento - Concluido): ");
                status = Console.ReadLine();
            }
            Tarefa.Status statusFinal = (Tarefa.Status)Enum.Parse(typeof(Tarefa.Status), status, true);

            Console.Write("Digite a prioridade da tarefa - (Baixa - Média - Alta): ");
            string prioridade = Console.ReadLine();

            while (!Enum.TryParse(prioridade, true, out Tarefa.Prioridade prioridadeEnum))
            {
                Console.WriteLine();
                Console.WriteLine("Digite uma opção válida.");
                Console.WriteLine();
                Console.Write("Digite a prioridade da tarefa - (Baixa - Média - Alta): ");
                prioridade = Console.ReadLine();
            }
            Tarefa.Prioridade prioridadeFinal = (Tarefa.Prioridade)Enum.Parse(typeof(Tarefa.Prioridade), prioridade, true);

            if (Listas.ListadeResponsavel.Count == 0)
            {
                Console.WriteLine("");
                Console.WriteLine("Não existe um Responsável criado. É necessário ter um para associar a uma Tarefa.");
                Responsavel objeto2 = instanciarResponsavel();
                Listas.addListaResponsavel(objeto2);
            }

            Console.WriteLine("");
            Console.WriteLine("=======================================");
            Console.WriteLine("          Lista de Responsáveis         ");
            Console.WriteLine("=======================================");
            foreach (Responsavel item in Listas.ListadeResponsavel)
            {
                int i = Listas.ListadeResponsavel.IndexOf(item);
                Console.WriteLine($"Id:{i} - Nome: {item.Nome} ({item.Email})");
                Console.WriteLine("=======================================");

            }
            Console.WriteLine("");
            Console.WriteLine($"Digite o Id do Responsável pela Tarefa: {titulo}");
            Console.Write("Id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Responsavel responsavel = Listas.ListadeResponsavel[id];


            Tarefa objeto = new Tarefa(titulo, data, statusFinal, prioridadeFinal, responsavel);
            return objeto;
        }
        public static void excluirTarefa()
        {
            if (Listas.ListadeTarefa.Count == 0)
            {
                Console.WriteLine("=======================================");
                Console.WriteLine("       Não há Tarefas criadas ainda.      ");
                Console.WriteLine("=======================================");
            }
            else
            {
                Listas.ExibirListaTarefa();
                Console.WriteLine();
                Console.Write("Digite o Id da tarefa que deseja excluir: ");
                int id = Convert.ToInt32(Console.ReadLine());

                if (id >= 0 && id < Listas.ListadeTarefa.Count)
                {
                    Listas.ListadeTarefa.RemoveAt(id);
                    Console.WriteLine("Tarefa excluida.");
                }
                else
                {
                    Console.WriteLine("Digite um Id válido. (Lembrando que os Id's são exibido em listagem.)");
                }
            }
            
        }

        public static void AtualizarTarefa()
        {
            string menu = @"Digite a opção que deseja atualizar.
1 - Título
2 - Data Limite
3 - Status
4 - Prioridade
5 - Responsável
0 - Sair
";
            if (Listas.ListadeTarefa.Count == 0)
            {
                Console.WriteLine("=======================================");
                Console.WriteLine("       Não há Tarefas criadas ainda.      ");
                Console.WriteLine("=======================================");
            }
            else
            {
                Console.WriteLine();
                Listas.ExibirListaTarefa();
                Console.WriteLine();
                Console.WriteLine("Digite o Id da Tarefa que deseja atualizar.");
                Console.Write("Id:");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                Tarefa tarefaAAtualizar = Listas.ListadeTarefa[id];

                Console.WriteLine($@"Você selecionou a Tarefa: Id:{id} - Nome: [{tarefaAAtualizar.Titulo}] para ser atualizada.");

                Console.WriteLine();
                Console.WriteLine(menu);
                Console.Write("Opção:");
                string decisao = Console.ReadLine();


                do
                {
                    switch (decisao)
                    {
                        case "1":
                            Console.WriteLine("");
                            Console.Write("Digite o novo Título da tarefa: ");
                            string titulo = Console.ReadLine();
                            Listas.ListadeTarefa[id].Titulo = titulo;
                            Console.WriteLine("");
                            Console.WriteLine($"Título da Tarefa Id:{id} atualizado. Novo título: {Listas.ListadeTarefa[id].Titulo}");
                            Console.WriteLine("");
                            break;

                        case "2":
                            Console.WriteLine("");
                            Console.Write("Digite a nova Data Limite - (formato dd/mm/yyyy): ");
                            DateOnly data = DateOnly.Parse(Console.ReadLine());
                            Listas.ListadeTarefa[id].DataLimite = data;
                            Console.WriteLine("");
                            Console.WriteLine($"Data Limite da Tarefa Id:{id} atualizado. Nova Data Limite: {Listas.ListadeTarefa[id].DataLimite}");
                            Console.WriteLine("");
                            break;

                        case "3":
                            Console.WriteLine("");
                            Console.Write("Digite o novo Status da tarefa - (Fazer - Andamento - Concluido):");
                            string status = Console.ReadLine();

                            while (!Enum.TryParse(status, true, out Tarefa.Status statusEnum))
                            {
                                Console.Write("Digite o novo Status da tarefa - (Fazer - Andamento - Concluido):");
                                status = Console.ReadLine();
                            }
                            Tarefa.Status statusFinal = (Tarefa.Status)Enum.Parse(typeof(Tarefa.Status), status, true);
                            Listas.ListadeTarefa[id].statusTarefa = statusFinal;
                            Console.WriteLine("");
                            Console.WriteLine($"Status da Tarefa Id:{id} atualizado. Novo Status: {Listas.ListadeTarefa[id].statusTarefa}");
                            Console.WriteLine("");
                            break;

                        case "4":
                            Console.WriteLine("");
                            Console.Write("Digite a nova Prioridade da tarefa - (Baixa - Média - Alta):");
                            string prioridade = Console.ReadLine();

                            while (!Enum.TryParse(prioridade, true, out Tarefa.Prioridade prioridadeEnum))
                            {
                                Console.Write("Digite a nova prioridade da tarefa - (Baixa - Média - Alta):");
                                prioridade = Console.ReadLine();
                            }
                            Tarefa.Prioridade prioridadeFinal = (Tarefa.Prioridade)Enum.Parse(typeof(Tarefa.Prioridade), prioridade, true);
                            Listas.ListadeTarefa[id].prioridadeTarefa = prioridadeFinal;
                            Console.WriteLine("");
                            Console.WriteLine($"Prioridade da Tarefa Id:{id} atualizado. Nova Prioridade: {Listas.ListadeTarefa[id].prioridadeTarefa}");
                            Console.WriteLine("");
                            break;

                        case "5":
                            if (Listas.ListadeResponsavel.Count == 0)
                            {
                                Console.WriteLine("");
                                Console.WriteLine("Não existe um Responsável criado. É necessário ter um para associar a uma Tarefa.");
                                Responsavel objeto2 = instanciarResponsavel();
                                Listas.addListaResponsavel(objeto2);
                            }

                            Console.WriteLine("=======================================");
                            Console.WriteLine("          Lista de Responsáveis         ");
                            Console.WriteLine("=======================================");
                            foreach (Responsavel item in Listas.ListadeResponsavel)
                            {
                                int i = Listas.ListadeResponsavel.IndexOf(item);
                                Console.WriteLine($"Id:{i} - Nome: {item.Nome} ({item.Email})");
                                Console.WriteLine("=======================================");

                            }
                            Console.WriteLine("");
                            Console.WriteLine($"Digite o Id do novo Responsável pela Tarefa");
                            Console.Write("Id: ");
                            int idRespo = Convert.ToInt32(Console.ReadLine());

                            Responsavel responsavel = Listas.ListadeResponsavel[id];
                            Listas.ListadeTarefa[id].responsavel = responsavel;
                            Console.WriteLine($"Responsável da Tarefa Id:{id} atualizado. Novo Responsável: {Listas.ListadeTarefa[id].responsavel.Nome}");
                            Console.WriteLine("");
                            break;
                        default:
                            Console.WriteLine("Digite uma opção válida.");
                            break;
                    }
                    Console.WriteLine(menu);
                    Console.Write("Opção:");
                    decisao = Console.ReadLine();


                } while (decisao != "0");
            }
            

        }
    }
}
