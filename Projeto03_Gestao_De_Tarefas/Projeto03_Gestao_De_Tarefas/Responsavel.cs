using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto03_Gestao_De_Tarefas
{
    public class Responsavel
    {
        public string Nome { get;}

        public string Email { get; set; }

        public Responsavel(string nome, string email)
        {
            this.Nome = nome;

            this.Email = email;
        }

    }
}





