using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_2Test_2.DTOs
{
    public class ClientDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<OrderDTO> Orders { get; set; }

    }
}
