using Airline.Application.Flight.Commands;
using Airline.Application.Flight.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Application.Flight.FlightProfile
{
    public class FlightProfile : AutoMapper.Profile
    {
        public FlightProfile()
        {
            CreateMap<Domain.Entities.Flight, AddFlightCommand>()
                .ReverseMap();
            CreateMap<Domain.Entities.Flight, GetFlightDTO>()
                .ForMember(fl => fl.Airline, opt => opt.MapFrom(fl => fl.Airline))
                .ForMember(fl => fl.FromAirport, opt => opt.MapFrom(fl => fl.FromAirport))
                .ForMember(fl => fl.ToAirport, opt => opt.MapFrom(fl => fl.ToAirport))
                .ForMember(fl=>fl.Reservations,opt=>opt.MapFrom(fl=>fl.Reservations))
                .ReverseMap();
        }
    }
}
