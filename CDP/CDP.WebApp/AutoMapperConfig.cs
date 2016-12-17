using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDP.WebApp
{
    public static class AutoMapperConfig
    {
        public static void Config()
        {
            Mapper.CreateMap<CDP.Domain.Chofer, CDP.WebApp.Models.ChoferViewModels>();
            Mapper.CreateMap<CDP.WebApp.Models.ChoferViewModels, CDP.Domain.Chofer>();
        }
    }
}
