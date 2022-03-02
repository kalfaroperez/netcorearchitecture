using AutoMapper;
using GroupTD.ECommerce.Application.DTO;
using GroupTD.ECommerce.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroupTD.ECommerce.Transversal.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customers, CustomersDto>().ReverseMap();

            //CreateMap<Customers, CustomersDto>().ReverseMap()
            //    .ForMember(destination => destination.CustomerID, source => source.MapFrom(x => x.CustomerID))
            //    .ForMember(destination => destination.CompanyName, source => source.MapFrom(x => x.CompanyName))
            //    .ForMember(destination => destination.ContactName, source => source.MapFrom(x => x.ContactName))
            //    .ForMember(destination => destination.ContactTitle, source => source.MapFrom(x => x.ContactTitle))
            //    .ForMember(destination => destination.Address, source => source.MapFrom(x => x.Address))
            //    .ForMember(destination => destination.City, source => source.MapFrom(x => x.City))
            //    .ForMember(destination => destination.Region, source => source.MapFrom(x => x.Region))
            //    .ForMember(destination => destination.PostalCode, source => source.MapFrom(x => x.PostalCode))
            //    .ForMember(destination => destination.Country, source => source.MapFrom(x => x.Country))
            //    .ForMember(destination => destination.Phone, source => source.MapFrom(x => x.Phone))
            //    .ForMember(destination => destination.Fax, source => source.MapFrom(x => x.Fax)).ReverseMap();
        }
    }
}
