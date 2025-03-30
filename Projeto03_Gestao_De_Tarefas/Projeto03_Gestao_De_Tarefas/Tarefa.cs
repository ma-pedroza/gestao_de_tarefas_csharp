using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto03_Gestao_De_Tarefas
{
    internal class Tarefa
    {
        public enum Status
        {
            Fazer,
            Andamento,
            Concluido
        }

        public enum Prioridade
        {
            Alta,
            Baixa,
            Media
        }
        public string Titulo { get; set; }
        public DateOnly DataLimite { get; set; }
        public Status statusTarefa { get; set; }
        public Prioridade prioridadeTarefa { get; set; }
        public string Responsavel { get; set; }

        public Responsavel responsavel {get; set;}

        public Tarefa(string Titulo, DateOnly DataLimite, Status status, Prioridade prioridade, Responsavel responsavel)
        {
            this.Titulo = Titulo;
            this.DataLimite = DataLimite;
            this.statusTarefa = status;
            this.prioridadeTarefa = prioridade;
            this.responsavel = responsavel;
        }
    }
}
