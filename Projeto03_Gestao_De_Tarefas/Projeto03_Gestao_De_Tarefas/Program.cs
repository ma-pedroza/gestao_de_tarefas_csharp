namespace Projeto03_Gestao_De_Tarefas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("To do list");
            string Menu = @"
1 - Novo responsável
2 - Nova tarefa
3 - Excluir tarefa
4 - Atualizar tarefa
5.1 - Lista tarefas
5.2 - Listar tarefas pendentes
5.3 - Listar tarefas concluidas
6.1 - Listar tarefas por responsável
6.2 - Listar tarefas pendentes por responsável
6.3 - Listar tarefas concluidas por responsável
0 - Encerrar programa";

            string opcao = "0";

            do
            {
                Console.WriteLine(Menu);
                opcao = Console.ReadLine();

                switch (opcao)
                {

                }

            } while (opcao != "0");
        }

        
    }
}
