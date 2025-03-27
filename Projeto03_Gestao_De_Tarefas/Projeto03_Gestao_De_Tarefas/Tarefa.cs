using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto03_Gestao_De_Tarefas
{
    internal class Tarefa
    {
        public string Titulo { get; set; }
        public DateOnly DataLimite { get; set; }
        public string Status { get; set; }
        public string Prioridade { get; set; }
        public string Responsavel { get; set; }

        public Tarefa(string Titulo, DateOnly DataLimite, string Status, string Prioridade)
        {
            this.Titulo = Titulo;
            this.DataLimite = DataLimite;
            this.Status = Status;
            this.Prioridade = Prioridade;
        }
    }


}
