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

            Console.Write("Digite a prioridade da tarefa - (Baixa - Media - Alta):");
            string prioridade = Console.ReadLine();

            while (!Enum.TryParse(prioridade, true, out Tarefa.Prioridade prioridadeEnum))
            {
                Console.Write("Digite o status da tarefa - (Fazer - Andamento - Concluido):");
                prioridade = Console.ReadLine();
            }

            Tarefa objeto = new Tarefa(titulo, data, statusEnum, prioridadeEnum);
            return objeto;
        }
    }
}
