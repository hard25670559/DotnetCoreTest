using System;
using System.Collections.Generic;

namespace ManyToManyTest.Model
{
    public class User : BaseModel
    {

        public string Name { get; set; }
        public List<UserProduct> Products { get; set; }

    }
}
