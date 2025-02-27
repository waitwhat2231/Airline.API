using Airline.Application.Reservation.Commands.Add;
using Airline.Application.Reservation.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Application.Reservation.Profile
{
    public class ReservationProfile : AutoMapper.Profile
    {
        public ReservationProfile()
        {
            CreateMap<Domain.Entities.ReservationEntities.Reservation, AddReservationCommand>()
                .ReverseMap();
            CreateMap<Domain.Entities.ReservationEntities.Reservation, ReservationDto>()
                .ForMember(r => r.Passenger, opt => opt.MapFrom(src => src.Passenger))
                .ReverseMap();
        }
    }
}
