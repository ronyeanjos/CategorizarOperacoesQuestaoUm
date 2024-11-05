using CategorizarOperacoesQuestaoUm.Implementacoes;
using CategorizarOperacoesQuestaoUm.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategorizarOperacoesQuestaoUm
{
    public class ValidacaoDasOperacoes 
    {
        
        private readonly IClassificacaoCategorias _classificacaoCategorias;

        public ValidacaoDasOperacoes(IClassificacaoCategorias classificacaoCategorias)
        {
            _classificacaoCategorias = classificacaoCategorias ?? throw new ArgumentNullException(nameof(classificacaoCategorias));
        }


        public List<string> ValidarOperacoes(List<string> operacoesRealizadas, DateTime dataReferencia)
        {

            List<string> operacoesClassificadas = new List<string>();

            for (int i = 0; i < operacoesRealizadas.Count; i++)
            {
                List<string> linhaDaOperacao = new List<string>(operacoesRealizadas[i].Split(" "));

                double valor = double.Parse(linhaDaOperacao[0]);
                string setorCliente = linhaDaOperacao[1];
                DateTime proximaDataPagamento = DateTime.Parse(linhaDaOperacao[2]);

                operacoesClassificadas.Add(_classificacaoCategorias.ClassificarCategoria(valor, 
                                                                                         setorCliente, 
                                                                                         proximaDataPagamento, 
                                                                                         dataReferencia));

            }

            return operacoesClassificadas;
        }
        
    }
}
