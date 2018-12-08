using Lojinha.Core.Models;
using Lojinha.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lojinha.Controllers
{
    [Authorize]
    public class CarrinhoController: Controller
    {
        private readonly IProdutoServices _produtoServices;

        private readonly ICarrinhoServices _carrinhoServices;


        public CarrinhoController(IProdutoServices produtoServices, ICarrinhoServices carrinhoServices)
        {
            _produtoServices = produtoServices;
            _carrinhoServices = carrinhoServices;
        }
        public async Task<IActionResult> Add(string id)
        {
            var usuario = HttpContext.User.Identity.Name;

            Carrinho carrinho =  _carrinhoServices.Obter(usuario);

            carrinho.Add(await _produtoServices.ObterProduto(id));

            _carrinhoServices.Salvar(usuario, carrinho);

            return PartialView("Index", carrinho);

        }

        public IActionResult Finalizar()
        {
            var usuario = HttpContext.User.Identity.Name;
            var carrinho = _carrinhoServices.Obter(usuario);

            //TODO: Inserir Mensagem na Queue




             _carrinhoServices.Limpar(usuario);

            return View(carrinho);
        }
    }
}
