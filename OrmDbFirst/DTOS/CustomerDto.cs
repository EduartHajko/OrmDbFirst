using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrmDbFirst.DTOS
{
    public  class CustomerDto
    {
        public string CustomerName { get; set; }
            
        public string CustomerAddress { get; set; }

        public DateTime DateCreated { get; set; }


    }
}
