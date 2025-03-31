using System;
using System.Collections.Generic;
using Projeto03_Gestao_De_Tarefas;

class SeedData
{
    public static void Seed()
    {
        Random rand = new Random();

        // Criar e adicionar 5 responsáveis
        string[] nomesResponsaveis = { "Ana Souza", "Carlos Lima", "Mariana Silva", "João Pereira", "Fernanda Costa" };
        List<Responsavel> listaResponsaveis = new List<Responsavel>();

        foreach (string nome in nomesResponsaveis)
        {
            Responsavel responsavel = new Responsavel(nome, $"{nome.ToLower().Replace(" ", "")}@email.com");
            Listas.addListaResponsavel(responsavel);
            listaResponsaveis.Add(responsavel);
        }

        // Criar e adicionar 15 tarefas
        string[] nomesTarefas = {
            "Revisar código", "Escrever documentação", "Corrigir bugs", "Testar aplicação", "Criar banco de dados",
            "Refatorar módulo X", "Desenvolver API", "Integrar sistema", "Melhorar desempenho", "Revisar UI/UX",
            "Planejar sprint", "Escrever testes unitários", "Implementar autenticação", "Corrigir falhas de segurança", "Otimizar consultas SQL"
        };

        for (int i = 0; i < 15; i++)
        {
            Tarefa.Status statusAleatorio = (Tarefa.Status)rand.Next(3); // 0 = Fazer, 1 = Andamento, 2 = Concluído
            Tarefa.Prioridade prioridadeAleatoria = (Tarefa.Prioridade)rand.Next(3); // 0 = Baixa, 1 = Média, 2 = Alta
            Responsavel responsavelAleatorio = listaResponsaveis[rand.Next(listaResponsaveis.Count)];

            Tarefa tarefa = new Tarefa(nomesTarefas[i], DateOnly.FromDateTime(DateTime.Now.AddDays(rand.Next(1, 30))), statusAleatorio, prioridadeAleatoria, responsavelAleatorio);
            Listas.addListaTarefa(tarefa);
        }

        // Exibir os dados carregados
        Console.WriteLine("✅ Dados de teste carregados com sucesso!\n");

        Console.WriteLine("📋 Responsáveis:");
        Listas.ExibirListaResponsavel();

        Console.WriteLine("\n📝 Tarefas:");
        Listas.ExibirListaTarefa();
    }
}
