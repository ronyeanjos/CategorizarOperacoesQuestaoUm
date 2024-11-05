using CategorizarOperacoesQuestaoUm;
using CategorizarOperacoesQuestaoUm.Implementacoes;
using CategorizarOperacoesQuestaoUm.Interfaces;
using Microsoft.Extensions.DependencyInjection;



var serviceProvider = new ServiceCollection()
    .AddScoped<IClassificacaoClientePrivate, ClassificacaoClientePrivate>()
    .AddScoped<IClassificacaoClientePublic, ClassificacaoClientePublic>()
    .AddScoped<IClassificacaoCategorias, ClassificacaoCategorias>()
    .AddScoped<ValidacaoDasOperacoes>()
    .BuildServiceProvider();

var validacaoDasOperacoes = serviceProvider.GetService<ValidacaoDasOperacoes>()
    ?? throw new InvalidOperationException("A instância  de ValidacaoDasOperacoes não pôde ser criada.");

DateTime DataReferencia;
int QuantidadeTransacoes;
List<string> Transacoes = [];
List<string> RetornoDasCategorias = [];


Console.WriteLine("Por favor preencher a data referencia: ");
DataReferencia = DateTime.Parse(Console.ReadLine());

Console.WriteLine("Por favor preencher a quantidade de transações que serão inseridas");
QuantidadeTransacoes = int.Parse(Console.ReadLine());

Console.WriteLine("Por favor preencher a transação:");

for (int i = 0; i < QuantidadeTransacoes; i++)
{
    Transacoes.Add(Console.ReadLine());
}

if (QuantidadeTransacoes == Transacoes.Count)
{
    RetornoDasCategorias = validacaoDasOperacoes.ValidarOperacoes(Transacoes, DataReferencia);
}
else 
{
    throw new InvalidOperationException("A quantidade de transacoes digitadas é diferente da quantidade de transacoes inseridas.");
}

foreach(string s in RetornoDasCategorias)
{
    Console.WriteLine(s);
}

Console.ReadKey();


