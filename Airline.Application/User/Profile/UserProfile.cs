using Airline.Application.User.Commands;
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
        }
    }
}
