using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Second_Task.Apps.AdminApi.DTOs.ProductDTOs
{
    public class ProductListItemDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public double Price { get; set; }
        public double Cost { get; set; }
        public int CategoryId { get; set; }

    }
}
