using Projeto03_Gestao_De_Tarefas;

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
        case "1":
            Responsavel objeto = Funcoes.instanciarResponsavel(); // Instancia a classe Responsavel e guarda em variavel
            Listas.addListaResponsavel(objeto); // Adiciona a variavel(objeto) na lista de responsáveis
            Listas.ExibirListaResponsavel(); // Exibe a lista somente para teste
            break;

        case "2":
            Tarefa objetoTarefa = Funcoes.instanciarTarefa(); // Instancia a classe Tarefa e guarda em variavel
            Listas.addListaTarefa(objetoTarefa); // Adiciona a variavel(objetoTarefa) na lista de tarefas
            Listas.ExibirListaTarefa(); // Exibe a lista somente para teste
            break;
        case "3":
            Funcoes.excluirTarefa();
            break;

        default:
            Console.WriteLine("Digite uma opção válida"); break;
    }

} while (opcao != "0");
