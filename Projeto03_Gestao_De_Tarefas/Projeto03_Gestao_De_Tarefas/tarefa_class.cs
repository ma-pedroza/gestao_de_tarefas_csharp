using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_claudinei
{
    internal class tarefa
    {
        public string titulo { get; set; }
        public DateOnly DataLimite { get; set; }
        public string Status { get; set; }
        public string Prioridade { get; set; }
        public string Responsavel { get; set; }
    }
}
