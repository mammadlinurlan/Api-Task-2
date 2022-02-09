using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Second_Task.Data.Entities
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public double Cost { get; set; }
        public bool IsDeleted { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
