using System;
using AutoMapper;
using hacka_getnet.DTO;
using hacka_getnet.Entidades;

namespace hacka_getnet.Mappers
{
    public class ConfigurationMapper : Profile
    {
        public ConfigurationMapper()
        {

            CreateMap<CadastroEmpreendedorDTO, Empreendedor>();
            CreateMap<CadastroIncentivadorDTO, Incentivador>();
            CreateMap<CadastroSolicitacaoCreditoDTO, SolicitacaoCredito>();


            CreateMap<Empreendedor, EmpreendedorDTO>();
            CreateMap<Incentivador, IncentivadorDTO>();
            CreateMap<SolicitacaoCredito, SolicitacaoCreditoDTO>();

            CreateMap<EnderecoEmpreendedor, EnderecoEmpreendedorDTO>();
            CreateMap<CartaoEmpreendedor, CartaoEmpreendedorDTO>();


            CreateMap<EmpreendedorDTO, Empreendedor>();                
            CreateMap<IncentivadorDTO, Incentivador>();
            CreateMap<SolicitacaoCreditoDTO, SolicitacaoCredito>();

            CreateMap<EnderecoEmpreendedorDTO, EnderecoEmpreendedor>();
            CreateMap<CartaoEmpreendedorDTO, CartaoEmpreendedor>();
        }

    }
}
