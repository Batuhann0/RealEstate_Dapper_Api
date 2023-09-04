using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate_Dapper_UI.Dtos.ProductDtos
{
    public class ResultProductDtos
    {
        public int ProductID { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string City { get; set; }
        public string image { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public string CategoryName { get; set; }

    }
}
