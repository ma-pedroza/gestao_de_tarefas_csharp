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
            Console.Write("Digite o nome do responsável: ");
            string nome = Console.ReadLine();
            Console.Write("Digite o email: ");
            string email = Console.ReadLine();

            Responsavel objeto = new Responsavel(nome, email);
            return objeto;
        }

        public static Tarefa instanciarTarefa()
        {
            Console.WriteLine("");
            Console.Write("Digite o título da tarefa: ");
            string titulo = Console.ReadLine();

            Console.Write("Digite a data limite - (formato dd/mm/yyyy): ");
            DateOnly data = DateOnly.Parse(Console.ReadLine());

            Console.Write("Digite o status da tarefa - (Fazer - Andamento - Concluido):");
            string status = Console.ReadLine();

            while (!Enum.TryParse(status, true, out Tarefa.Status statusEnum))
            {
                Console.Write("Digite o status da tarefa - (Fazer - Andamento - Concluido):");
                status = Console.ReadLine();
            }
            Tarefa.Status statusFinal = (Tarefa.Status)Enum.Parse(typeof(Tarefa.Status), status, true);

            Console.Write("Digite a prioridade da tarefa - (Baixa - Média - Alta):");
            string prioridade = Console.ReadLine();

            while (!Enum.TryParse(prioridade, true, out Tarefa.Prioridade prioridadeEnum))
            {
                Console.Write("Digite a prioridade da tarefa - (Baixa - Média - Alta):");
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

            Console.WriteLine("============================");
            Console.WriteLine("    Lista de Responsáveis    ");
            Console.WriteLine("============================");
            foreach (Responsavel item in Listas.ListadeResponsavel)
            {
                int i = Listas.ListadeResponsavel.IndexOf(item);
                Console.WriteLine($"Id:{i} - Nome: {item.Nome} ({item.Email})");
                Console.WriteLine("============================");

            }
            Console.WriteLine($"Digite o Id do Responsável pela Tarefa: {titulo}");
            Console.Write("Id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Responsavel responsavel = Listas.ListadeResponsavel[id];


            Tarefa objeto = new Tarefa(titulo, data, statusFinal, prioridadeFinal, responsavel);
            return objeto;
        }
        public static void excluirTarefa()
        {
            Console.Write("Digite o Id da tarefa que deseja excluir");
            int id = Convert.ToInt32(Console.ReadLine());

            if (id <= 0 && id < Listas.ListadeTarefa.Count)
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
}
