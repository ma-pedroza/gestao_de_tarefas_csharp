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
            if(ListadeTarefa.Count == 0)
            {
                Console.WriteLine("=======================================");
                Console.WriteLine("       Não há Tarefas criadas ainda.      ");
                Console.WriteLine("=======================================");
            }
            else
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
            
        }
        public static void ExibirListaTarefaConcluidas()
        {
            List<Tarefa> ListadeTarefasConcluida = new List<Tarefa>();

            foreach (Tarefa item in ListadeTarefa)
            {
                if (item.statusTarefa == Tarefa.Status.Concluido)
                {
                    ListadeTarefasConcluida.Add(item);
                }
            }

            if(ListadeTarefasConcluida.Count <= 0)
            {
                Console.WriteLine("");
                Console.WriteLine("=======================================");
                Console.WriteLine("        Não há tarefas concluídas   ");
                Console.WriteLine("=======================================");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("=======================================");
                Console.WriteLine("        Lista de Tarefas Concluidas   ");
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
            
        }


        public static void ExibirListaTarefasPendentes()
        {
            List<Tarefa> ListadeTarefasPendentes = new List<Tarefa>();

            foreach (Tarefa item in ListadeTarefa)
            {
                if (item.statusTarefa == Tarefa.Status.Fazer || item.statusTarefa == Tarefa.Status.Andamento)
                {
                    ListadeTarefasPendentes.Add(item);
                }
            }

            if (ListadeTarefasPendentes.Count <= 0)
            {
                Console.WriteLine("");
                Console.WriteLine("=======================================");
                Console.WriteLine("        Não há Tarefas Pendentes   ");
                Console.WriteLine("=======================================");

            }
            else
            {
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

            
        }

        public static void ExibirTarefasPorResponsavel()
        {
            if (ListadeResponsavel.Count <= 0)
            {
                Console.WriteLine("");
                Console.WriteLine("=======================================");
                Console.WriteLine($"     Não há nenhum Responsável criado  ");
                Console.WriteLine("=======================================");
            }
            else
            {
                Console.WriteLine("Escolha um responsável abaixo:");
                Listas.ExibirListaResponsavel();


                bool cond = false;
                int id = -1;
                while (cond != true)
                {
                    Console.Write("Digite o id: ");
                    Console.Write("Id: ");
                    id = Convert.ToInt32(Console.ReadLine());

                    if (id < 0 || id > (Listas.ListadeResponsavel.Count) - 1)
                    {
                        Console.WriteLine("Opção inválida! - Escolha um ID existente");
                        cond = false;
                    }

                    else if (id >= 0 && id <= (Listas.ListadeResponsavel.Count) - 1)
                    {
                        cond = true;

                    }
                }

                List<Tarefa> ListadeTarefasPorResponsavel = new List<Tarefa>();

                Responsavel responsavelParaBusca = Listas.ListadeResponsavel[id];

                foreach (Tarefa item in ListadeTarefa)
                {
                    if (item.responsavel.Email == responsavelParaBusca.Email)
                    {
                        ListadeTarefasPorResponsavel.Add(item);
                    }
                }
                if (ListadeTarefasPorResponsavel.Count <= 0)
                {
                    Console.WriteLine("");
                    Console.WriteLine("=======================================");
                    Console.WriteLine($"     Não há nenhuma tarefa de: {responsavelParaBusca.Nome}  ");
                    Console.WriteLine("=======================================");
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("=======================================");
                    Console.WriteLine($"      Lista de Tarefas de:    ");
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
            }
        }
        public static void ExibirTarefasPendentesResponsavel()
        {
            List<Tarefa> ListaTarefasPendentesResponsavel = new List<Tarefa>();

            if(ListadeResponsavel.Count <= 0)
            {
                Console.WriteLine("");
                Console.WriteLine("=======================================");
                Console.WriteLine($"     Não há nenhum Responsável criado  ");
                Console.WriteLine("=======================================");
            }
            else
            {
                Console.WriteLine("Escolha um responsável abaixo:");
                Listas.ExibirListaResponsavel();

                bool cond = false;
                int id = -1;
                while (cond != true)
                {
                    Console.Write("Digite o id: ");
                    Console.Write("Id: ");
                    id = Convert.ToInt32(Console.ReadLine());

                    if (id < 0 || id > (Listas.ListadeResponsavel.Count) - 1)
                    {
                        Console.WriteLine("Opção inválida! - Escolha um ID existente");
                        cond = false;
                    }

                    else if (id >= 0 && id <= (Listas.ListadeResponsavel.Count) - 1)
                    {
                        cond = true;

                    }
                }

                Responsavel responsavelParaBusca = Listas.ListadeResponsavel[id];

                foreach (Tarefa item in ListadeTarefa)
                {
                    if ((item.responsavel.Email == responsavelParaBusca.Email) && (item.statusTarefa == Tarefa.Status.Fazer || item.statusTarefa == Tarefa.Status.Andamento))
                    {
                        ListaTarefasPendentesResponsavel.Add(item);
                    }
                }
                if (ListaTarefasPendentesResponsavel.Count <= 0)
                {
                    Console.WriteLine("");
                    Console.WriteLine("=======================================");
                    Console.WriteLine($"      Não há tarefas pendentes de: {responsavelParaBusca.Nome}   ");
                    Console.WriteLine("=======================================");
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("=======================================");
                    Console.WriteLine($"      Lista de Tarefas de Pendentes de: {responsavelParaBusca.Nome}   ");
                    Console.WriteLine("=======================================");
                    foreach (Tarefa item in ListaTarefasPendentesResponsavel)
                    {
                        int index = ListaTarefasPendentesResponsavel.IndexOf(item);
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

        public static void ExibirTarefasConcluidasResponsavel()
        {
            List<Tarefa> ListaTarefasConcluidasResponsavel = new List<Tarefa>();

            if (ListadeResponsavel.Count <= 0)
            {
                Console.WriteLine("");
                Console.WriteLine("=======================================");
                Console.WriteLine($"     Não há nenhum Responsável criado  ");
                Console.WriteLine("=======================================");
            }
            else
            {
                Console.WriteLine("Escolha um responsável abaixo:");
                Listas.ExibirListaResponsavel();

                bool cond = false;
                int id = -1;
                while (cond != true)
                {
                    Console.Write("Digite o id: ");
                    Console.Write("Id: ");
                    id = Convert.ToInt32(Console.ReadLine());

                    if (id < 0 || id > (Listas.ListadeResponsavel.Count) - 1)
                    {
                        Console.WriteLine("Opção inválida! - Escolha um ID existente");
                        cond = false;
                    }

                    else if (id >= 0 && id <= (Listas.ListadeResponsavel.Count) - 1)
                    {
                        cond = true;

                    }
                }

                Responsavel responsavelParaBusca = Listas.ListadeResponsavel[id];

                foreach (Tarefa item in Listas.ListadeTarefa)
                {
                    if ((item.responsavel.Email == responsavelParaBusca.Email) && (item.statusTarefa == Tarefa.Status.Concluido))
                    {
                        ListaTarefasConcluidasResponsavel.Add(item);
                    }
                }
                if (ListaTarefasConcluidasResponsavel.Count <= 0)
                {
                    Console.WriteLine("");
                    Console.WriteLine("=======================================");
                    Console.WriteLine($"      Não há tarefas concluidas de: {responsavelParaBusca.Nome}   ");
                    Console.WriteLine("=======================================");
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("=======================================");
                    Console.WriteLine($"      Lista de Tarefas de Concluidas de: {responsavelParaBusca.Nome}   ");
                    Console.WriteLine("=======================================");
                    foreach (Tarefa item in ListaTarefasConcluidasResponsavel)
                    {
                        int index = ListaTarefasConcluidasResponsavel.IndexOf(item);
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
    }
}


