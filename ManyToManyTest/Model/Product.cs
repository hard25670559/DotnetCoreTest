using System;
using System.Collections.Generic;

namespace ManyToManyTest.Model
{
    public class Product : BaseModel
    {

        public string Name { get; set; }
        public List<User> Users { get; set; }

    }
}
