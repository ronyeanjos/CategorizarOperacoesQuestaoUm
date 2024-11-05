using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategorizarOperacoesQuestaoUm.Interfaces
{
    public interface IClassificacaoCategorias
    {
        string ClassificarCategoria(double valor, string setorCliente, DateTime proximaDataPagamento, DateTime dataReferencia);
    }
}
