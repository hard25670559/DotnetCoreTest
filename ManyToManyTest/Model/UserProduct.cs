using System;

namespace ManyToManyTest.Model
{
    public class UserProduct : BaseModel
    {

        public User User { get; set; }
        public Product Product { get; set; }

    }
}
