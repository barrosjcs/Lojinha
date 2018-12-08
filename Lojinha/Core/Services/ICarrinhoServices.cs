using Lojinha.Core.Models;
using System.Threading.Tasks;

namespace Lojinha.Core.Services
{
    public interface ICarrinhoServices
    {
        void Limpar(string usuario);
        Carrinho Obter(string usuario);
        void Salvar(string usuario, Carrinho carrinho);
    }
}