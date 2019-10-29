using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class BaseModel
    {

        public int Id { get; set; }
        public DateTime Create { get; set; }
        public DateTime Update { get; set; }
        public bool Delete { get; set; }


    }
}
