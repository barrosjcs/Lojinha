using Lojinha.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lojinha.Infraestructure.Storage
{
    public interface IAzureStorage
    {
        void AddProduto(Produto produto);

        Task<List<Produto>> ObterProdutos();
    }
}