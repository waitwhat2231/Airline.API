using Airline.Application.Airline.Commands.Add;
using Airline.Application.Airline.Commands.Update;
using Airline.Application.Airline.Dtos;
using Airline.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Application.Airline.Profile
{
    public class AirlineProfile :AutoMapper.Profile
    {
        public AirlineProfile()
        {
            CreateMap<Domain.Entities.Airline, AddAirlineCommand>()
                .ReverseMap();
            CreateMap<Domain.Entities.Airline, UpdateAirlineCommand>()
                .ReverseMap();
            CreateMap<Domain.Entities.Airline, GetAirlineDto>()
                .ForMember(ai => ai.Flights, opt => opt.MapFrom(src => src.Flights))
                .ReverseMap();
        }

        
    }
}
