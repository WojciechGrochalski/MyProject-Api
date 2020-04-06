using AutoMapper;
using MyProject.Currency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.AutoMapper
{
    public class AutoMapperConfig
    {

        public static IMapper Initialize()
           => new MapperConfiguration(cfg =>
           {
               
               cfg.CreateMap<ValueOfCurrency, CurrencyDTO>();
             
           })
           .CreateMapper();
    }
}
