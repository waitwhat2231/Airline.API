using Airline.Application.User.Commands.Register;
using Airline.Application.User.Commands.Register.AirlineManager;
using Airline.Application.User.DTO;
using Airline.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Application.User.Profile
{
    public class UserProfile : AutoMapper.Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterUserCommand,Domain.Entities.User>().ReverseMap();
            CreateMap<RegisterAirlineManagerCommand, Domain.Entities.User>().ReverseMap();
            CreateMap<Domain.Entities.User, UserInfoDTO>().ReverseMap();
        }
    }
}
