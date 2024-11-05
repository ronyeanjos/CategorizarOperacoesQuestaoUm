using CategorizarOperacoesQuestaoUm.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategorizarOperacoesQuestaoUm.Implementacoes
{
    public class ClassificacaoCategorias : IClassificacaoCategorias
    {

        public readonly IClassificacaoClientePrivate _classificacaoClientePrivate;
        public readonly IClassificacaoClientePublic _classificacaoClientePublic;

        public ClassificacaoCategorias(IClassificacaoClientePrivate classificacaoClientePrivate, 
                                    IClassificacaoClientePublic classificacaoClientePublic)
        {
            _classificacaoClientePrivate = classificacaoClientePrivate ?? throw new ArgumentNullException(nameof(classificacaoClientePrivate));
            _classificacaoClientePublic = classificacaoClientePublic ?? throw new ArgumentNullException(nameof(classificacaoClientePublic));
        }



        public string ClassificarCategoria(double valor, 
                                       string setorCliente, 
                                       DateTime proximaDataPagamento, 
                                       DateTime dataReferencia)
        {
            TimeSpan _dataCalculo = dataReferencia.Subtract(proximaDataPagamento);

            if (_dataCalculo.Days > Constantes.DAYS_EXPIRED && 
                    dataReferencia > proximaDataPagamento)
            {
                return Constantes.RISK_CATEGORIE_EXPIRED;
            }
            else if (setorCliente == Constantes.CLIENT_PRIVATE)
            {
                return _classificacaoClientePrivate.ClassificarClientePrivate(valor);
            }
            else if (setorCliente == Constantes.CLIENT_PUBLIC)
            {
                return _classificacaoClientePublic.ClassificarClientePublic(valor);
            }
            else
            {
                throw new ArgumentException("Não há esta categoria, por favor, procurar o administrador do Sistema.");
            }
        }

       


    }
}
