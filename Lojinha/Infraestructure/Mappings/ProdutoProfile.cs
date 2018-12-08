using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Mappers.Internal;
using Lojinha.Core.Models;
using Lojinha.Core.ViewModels;

namespace Lojinha.Infraestructure.Mappings
{
    //Herdando do Automapper
    public class ProdutoProfile: Profile
    {
        public ProdutoProfile()
        {
            //Mapeando as propriedades (ViewModel x Entidade)
            CreateMap<Produto, ProdutoViewModel>()
                .ForMember(p => p.Id, vm => vm.MapFrom(x => x.Id))
                .ForMember(p => p.Nome, vm => vm.MapFrom(x => x.Nome))
                .ForMember(p => p.Preco, vm => vm.MapFrom(x => x.Preco))
                .ForMember(p => p.ImagemUrl, vm => vm.MapFrom(x => x.ImagemPrincipalUrl));


        }
    }
}
