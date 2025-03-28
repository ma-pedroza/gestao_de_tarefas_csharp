using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto03_Gestao_De_Tarefas
{
    static class Listas
    {
        public static List<Responsavel> ListadeResponsavel = new List<Responsavel>();

        public static List<Tarefa> ListadeTarefa = new List<Tarefa>();
        public static void addListaResponsavel(Responsavel objeto)
        {
            ListadeResponsavel.Add(objeto);
        }

        public static void addListaTarefa(Tarefa objeto)
        {
            ListadeTarefa.Add(objeto);
        }

        public static void ExibirListaResponsavel()
        {
            Console.WriteLine("");
            Console.WriteLine("============================");
            Console.WriteLine("    Lista de Responsáveis    ");
            Console.WriteLine("============================");
            foreach (Responsavel item in ListadeResponsavel)
            {
                Console.WriteLine($"Nome: {item.Nome}");
                Console.WriteLine($"Email: {item.Email}");
                Console.WriteLine("============================");
            }
        }
        public static void ExibirListaTarefa()
        {
            Console.WriteLine("");
            Console.WriteLine("============================");
            Console.WriteLine("    Lista de Tarefa    ");
            Console.WriteLine("============================");
            foreach (Tarefa item in ListadeTarefa)
            {
                Console.WriteLine($"Título: {item.Titulo}");
                Console.WriteLine($"Data Limite: {item.DataLimite}");
                Console.WriteLine($"Status: {item.statusTarefa}");
                Console.WriteLine($"Prioridade: {item.prioridadeTarefa}");
                Console.WriteLine("============================");
            }
        }

    }

}
