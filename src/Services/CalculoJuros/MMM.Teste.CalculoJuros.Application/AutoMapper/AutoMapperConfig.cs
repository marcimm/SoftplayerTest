using AutoMapper;
using MMM.Test.Core.Models;
using MMM.Teste.CalculoJuros.Application.ViewModels;
using MMM.Teste.CalculoJuros.Models;

namespace MMM.Teste.CalculoJuros.Application.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            // Domain to View Model
            CreateMap<JurosCompostos, JurosCompostosViewModel>(); 
            CreateMap<ErrorDetails, ErrorDetailsViewModel>();
        }
    }
}
