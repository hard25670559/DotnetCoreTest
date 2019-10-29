using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Models
{
    public class Product : BaseModel
    {

        public string Name { get; set; }
        public int Price { get; set; }

    }
}
