using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Projeto03_Gestao_De_Tarefas
{
    static class Listas
    {
        public static List<Responsavel> ListadeResponsavel = new List<Responsavel>();

        public static List<Tarefa> ListadeTarefa = new List<Tarefa>();

        public static List<Tarefa> ListadeTarefasConcluida = new List<Tarefa>();

        public static List<Tarefa> ListadeTarefasPendentes = new List<Tarefa>();

        public static List<Tarefa> ListadeTarefasPorResponsavel = new List<Tarefa>();

        public static List <Tarefa> ListaTarefasPendentesResponsavel = new List<Tarefa>();



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
            Console.WriteLine("=======================================");
            Console.WriteLine("          Lista de Responsáveis         ");
            Console.WriteLine("=======================================");
            foreach (Responsavel item in ListadeResponsavel)
            {
                int index = ListadeResponsavel.IndexOf(item);
                Console.WriteLine($"Id: {index}");
                Console.WriteLine($"Nome: {item.Nome}");
                Console.WriteLine($"Email: {item.Email}");
                Console.WriteLine("=======================================");
            }
        }
        public static void ExibirListaTarefa()
        {
            Console.WriteLine("");
            Console.WriteLine("=======================================");
            Console.WriteLine("            Lista de Tarefa            ");
            Console.WriteLine("=======================================");
            foreach (Tarefa item in ListadeTarefa)
            {
                int index = ListadeTarefa.IndexOf(item);
                Console.WriteLine($"Id: {index}");
                Console.WriteLine($"Título: {item.Titulo}");
                Console.WriteLine($"Data Limite: {item.DataLimite}");
                Console.WriteLine($"Status: {item.statusTarefa}");
                Console.WriteLine($"Prioridade: {item.prioridadeTarefa}");
                Console.WriteLine($"Responsável: {item.responsavel.Nome} ({item.responsavel.Email})");
                Console.WriteLine("=======================================");
            }
        }
        public static void ExibirListaTarefaConcluidas()
        {
            ListadeTarefasConcluida.Clear();
            foreach (Tarefa item in ListadeTarefa)
            {
                if (item.statusTarefa == Tarefa.Status.Concluido)
                {
                    ListadeTarefasConcluida.Add(item);
                }
            }
            Console.WriteLine("");
            Console.WriteLine("=======================================");
            Console.WriteLine("      Lista de Tarefas Concluidas   ");
            Console.WriteLine("=======================================");
            foreach (Tarefa item in ListadeTarefasConcluida)
            {
                int index = ListadeTarefasConcluida.IndexOf(item);
                Console.WriteLine($"Id: {index}");
                Console.WriteLine($"Título: {item.Titulo}");
                Console.WriteLine($"Data Limite: {item.DataLimite}");
                Console.WriteLine($"Status: {item.statusTarefa}");
                Console.WriteLine($"Prioridade: {item.prioridadeTarefa}");
                Console.WriteLine($"Responsável: {item.responsavel.Nome} ({item.responsavel.Email})");
                Console.WriteLine("=======================================");
            }
        }


        public static void ExibirListaTarefasPendentes()
        {
            ListadeTarefasPendentes.Clear();
            foreach (Tarefa item in ListadeTarefa)
            {
                if (item.statusTarefa == Tarefa.Status.Fazer || item.statusTarefa == Tarefa.Status.Andamento)
                {
                    ListadeTarefasPendentes.Add(item);
                }
            }
            Console.WriteLine("");
            Console.WriteLine("=======================================");
            Console.WriteLine("       Lista de Tarefas Pendentes   ");
            Console.WriteLine("=======================================");
            foreach (Tarefa item in ListadeTarefasPendentes)
            {
                int index = ListadeTarefa.IndexOf(item);
                Console.WriteLine($"Id: {index}");
                Console.WriteLine($"Título: {item.Titulo}");
                Console.WriteLine($"Data Limite: {item.DataLimite}");
                Console.WriteLine($"Status: {item.statusTarefa}");
                Console.WriteLine($"Prioridade: {item.prioridadeTarefa}");
                Console.WriteLine($"Responsável: {item.responsavel.Nome} ({item.responsavel.Email})");
                Console.WriteLine("=======================================");

            }
        }

        public static void ExibirTarefasPorResponsavel()
        {
            Console.WriteLine("Escolha um responsável abaixo:");
            Listas.ExibirListaResponsavel();
            Console.Write("Digite o id: ");

            int id = Convert.ToInt32(Console.ReadLine());

            ListadeTarefasPorResponsavel.Clear();

            Responsavel responsavelParaBusca = Listas.ListadeResponsavel[id];

            foreach(Tarefa item in ListadeTarefa)
            {
                if(item.responsavel.Email == responsavelParaBusca.Email)
                {
                    ListadeTarefasPorResponsavel.Add(item);
                }
            }
            Console.WriteLine("");
            Console.WriteLine("=======================================");
            Console.WriteLine($"      Lista de Tarefas de {responsavelParaBusca.Nome}   ");
            Console.WriteLine("=======================================");
            foreach (Tarefa item in ListadeTarefasPorResponsavel)
            {
                int index = ListadeTarefasPorResponsavel.IndexOf(item);
                Console.WriteLine($"Id: {index}");
                Console.WriteLine($"Título: {item.Titulo}");
                Console.WriteLine($"Data Limite: {item.DataLimite}");
                Console.WriteLine($"Status: {item.statusTarefa}");
                Console.WriteLine($"Prioridade: {item.prioridadeTarefa}");
                Console.WriteLine($"Responsável: {item.responsavel.Nome} ({item.responsavel.Email})");
                Console.WriteLine("=======================================");
            }

        }
        public static void ExibirTarefasPendentesResponsavel()
        {
            ExibirListaResponsavel();
            Console.WriteLine("Escolha o responsável indicando seu email: ");
            string email = Console.ReadLine();

            foreach (Tarefa Item in ListadeTarefa)
            {
                if (Item.responsavel.Email == email && Item.statusTarefa == Tarefa.Status.Fazer || Item.statusTarefa == Tarefa.Status.Andamento)
                {
                    ListaTarefasPendentesResponsavel.Add(Item);
                }


            }

            Console.WriteLine("");
            Console.WriteLine("================================================================");
            Console.WriteLine("            Lista de Tarefa Pendentes por Responsável           ");
            Console.WriteLine("================================================================");
            foreach (Tarefa item in ListaTarefasPendentesResponsavel)
            {
                int index = ListadeTarefa.IndexOf(item);
                Console.WriteLine($"Id: {index}");
                Console.WriteLine($"Título: {item.Titulo}");
                Console.WriteLine($"Data Limite: {item.DataLimite}");
                Console.WriteLine($"Status: {item.statusTarefa}");
                Console.WriteLine($"Prioridade: {item.prioridadeTarefa}");
                Console.WriteLine($"Responsável: {item.responsavel.Nome} ({item.responsavel.Email})");
                Console.WriteLine("=======================================");
            }

        }

    }
}


