using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Second_Task.Data.Entities
{
    public class Category:BaseEntity
    {

        public string Name { get; set; }

        public bool IsDeleted { get; set; }
        public List<Product> Products { get; set; }

        public string Image { get; set; }

    }
}
