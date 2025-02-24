using Airline.Application.Airline.Dtos;
using Airline.Application.Airport.Commands;
using Airline.Application.Airport.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Application.Airport.AirportProfile
{
    public class AirportProfile : AutoMapper.Profile
    {
        public AirportProfile()
        {
            CreateMap<AddAirportCommand, Domain.Entities.Airport>()
                .ReverseMap();
            CreateMap<Domain.Entities.Airport, AirportDto>()
                .ForMember(ai => ai.FlightsFrom, opt => opt.MapFrom(src => src.FlightsFrom))
                .ForMember(ai=>ai.FlightsTo, opt => opt.MapFrom(src=>src.FlightsTo))
                .ReverseMap();
        }
    }
}
