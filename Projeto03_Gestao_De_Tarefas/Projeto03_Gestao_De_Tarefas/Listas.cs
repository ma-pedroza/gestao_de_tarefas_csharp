using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto03_Gestao_De_Tarefas
{
    public static class Listas
    {
        public static List<Responsavel> ListadeResponsavel = new List<Responsavel>();
        public static void addListaResponsavel(Responsavel objeto)
        {
            ListadeResponsavel.Add(objeto);
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

    }

}
