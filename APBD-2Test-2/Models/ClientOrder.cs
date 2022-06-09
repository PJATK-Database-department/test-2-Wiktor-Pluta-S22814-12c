using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_2Test_2.Models
{
    public class ClientOrder
    {
        [Key]
        public int IdClientOrder { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }

        public DateTime CompletionDate { get; set; }
        [MaxLength(300)]
        public string Comments { get; set; }

        public int IdClient { get; set; }
        [ForeignKey("IdClient")]
        public Client Client { get; set; }
        public int IdEmployee { get; set; }
        [ForeignKey("IdEmployee")]
        public Employee Employee { get; set; }
        public ICollection<ConfectioneryClientOrder> ConfectioneryClientOrders { get; set; }



    }
}
