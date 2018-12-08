using AutoMapper;
using Lojinha.Core.Models;
using Lojinha.Core.Services;
using Lojinha.Core.ViewModels;
using Lojinha.Infraestructure.Storage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lojinha.Controllers
{

    [Authorize]
    public class ProdutosController : Controller
    {
        //private readonly IAzureStorage _azureStorage;

        //public ProdutosController(IAzureStorage azureStorage)
        //{
        //    _azureStorage = azureStorage;
        //}

        //public IActionResult Create()
        //{
        //    var produto = new Produto
        //    {
        //        Id = 331132,
        //        Nome = "Android ",
        //        Categoria = new Categoria
        //        {
        //            Id = 2,
        //            Nome = "Smartphones"
        //        },
        //        Descricao = "Android Oreo",
        //        Fabricante = new Fabricante
        //        {
        //            Id = 2,
        //            Nome = "Motorola"
        //        },
        //        Preco = 1000m,
        //        Tags = new[] { "android", "celular", "smartphone", "motorola"},
        //        ImagemPrincipalUrl = "https://www.gazetadopovo.com.br/ra/mega/Pub/GP/p4/2018/10/04/Economia/Imagens/Cortadas/Motorola%20One-k2QD-U203918315556RFH-1024x683@GP-Web.jpg"

        //    };
        //    //TODO: ProdutoServico.Add
        //    _azureStorage.AddProduto(produto);
        //    return Content("OK");
        //}

        //public async Task<IActionResult> List()
        //{
        //    return Json(await _azureStorage.ObterProdutos());
        //}

        private readonly IProdutoServices _produtoStorage;
        private readonly IMapper _mapper; //Injeção de dependencia para o AutoMapper
        public ProdutosController(IProdutoServices produtoStorage, IMapper mapper)
        {
            _produtoStorage = produtoStorage;
            _mapper = mapper; //Injeção de dependencia para o AutoMapper
        }
        public async Task<IActionResult> List()
        {
            //return Json(await _produtoStorage.ObterProdutos());
            var produtos = await _produtoStorage.ObterProdutos();
            var vm = _mapper.Map<List<ProdutoViewModel>>(produtos); //Usando o AutoMapper

            return View(vm);
        }

        public async Task<IActionResult> Details(string id)
        {
            var produto = await _produtoStorage.ObterProduto(id);
            return Json(produto);

        }
    }
}
