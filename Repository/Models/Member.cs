using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Models
{
    public class Member : BaseModel
    {

        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Account { get; set; }
        public string Passowrd { get; set; }

    }
}
