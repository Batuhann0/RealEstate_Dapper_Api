﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate_Dapper_Api.Dtos.WhoWeAreDetailDtos
{
    public class ResultWhoWeAreDetailDto
    {
        public int WhoWeAreDetailID { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }

    }
}
