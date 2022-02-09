using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Second_Task.Apps.AdminApi.DTOs.CategoryDTOs
{
    public class CategoryGetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime ModifiedTime { get; set; }

        public string Image { get; set; }
    }
}
