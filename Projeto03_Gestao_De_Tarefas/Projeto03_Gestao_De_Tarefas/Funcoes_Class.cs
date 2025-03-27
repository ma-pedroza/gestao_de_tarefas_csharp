using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto03_Gestao_De_Tarefas
{
    static class Funcoes
    {
        public static Responsavel instanciarResponsavel()
        {
            Console.Write("Digite o nome do responsável:");
            string nome = Console.ReadLine();
            Console.Write("Digite o email:");
            string email = Console.ReadLine();

            Responsavel objeto = new Responsavel(nome, email);
            return objeto;
        }
    }
}
