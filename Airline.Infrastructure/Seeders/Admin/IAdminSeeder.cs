﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Infrastructure.Seeders.Admin
{
    public interface IAdminSeeder
    {
        public Task Seed();
    }
}
