using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_2Test_2.Models
{
    public class ConfectioneryClientOrder
    {
        public int IdClientOrder { get; set; }
        public ClientOrder ClientOrder { get; set; }
        public int IdConfectionery { get; set; }
        public Confectionery Confectionery { get; set; }

        public int Amount { get; set; }
        [MaxLength(300)]
        public string Comments { get; set; }

    }
}
