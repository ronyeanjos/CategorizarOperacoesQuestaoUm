using CategorizarOperacoesQuestaoUm.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategorizarOperacoesQuestaoUm.Implementacoes
{
    public class ClassificacaoClientePrivate : IClassificacaoClientePrivate
    {
        public string ClassificarClientePrivate(double valor)
        {
            if (valor > Constantes.RISK_VALUE)
            {
                return Constantes.RISK_CATEGORIE_HIGHRISK;
            }
            else
            {
                throw new ArgumentException("Não há esta categoria, por favor, procurar o administrador do Sistema.");
            }
        }
    }
}
