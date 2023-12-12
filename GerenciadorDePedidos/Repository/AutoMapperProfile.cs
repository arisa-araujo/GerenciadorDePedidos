using AutoMapper;
using GerenciadorDePedidos.Data;
using GerenciadorDePedidos.DTOS;
using Microsoft.AspNetCore.Mvc.TagHelpers;

namespace GerenciadorDePedidos.Repository
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerDTO, Customer>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<OrderTerms, OrderTermsDTO>();
            CreateMap<OrderTermsDTO, OrderTerms>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<OrderItem, OrderItemDTO>();
            CreateMap<OrderItemDTO, OrderItem>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<Order, OrderDTO>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer!.Name))
                .ForMember(dest => dest.OrderTermsName, opt => opt.MapFrom(src => src.OrderTerms!.Name));
            CreateMap<OrderDTO, Order>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}