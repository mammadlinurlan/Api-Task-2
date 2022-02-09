using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Second_Task.Apps.AdminApi.DTOs.ProductDTOs
{
    public class ProductGetDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public double Price { get; set; }
        public double Cost { get; set; }
        public bool IsDeleted { get; set; }

        public DateTime CreatedTime { get; set; }
        public DateTime ModifiedTime { get; set; }

        public int CategoryId { get; set; }
    }
}
