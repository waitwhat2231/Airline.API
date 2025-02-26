using Airline.Application.Reservation.Commands;
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
        }
    }
}
