﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate_Dapper_Api.Dtos.ServiceDtos
{
    public class CreateServiceDto
    {
        public string ServiceName { get; set; }
        public bool ServiceStatus { get; set; }
    }
}
