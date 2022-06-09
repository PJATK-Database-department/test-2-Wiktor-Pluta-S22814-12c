using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_2Test_2.Models
{
    public class Confectionery
    {
        [Key]
        public int IdConfectionery { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public float PricePerOne { get; set; }
        public ICollection<ConfectioneryClientOrder> ConfectioneryClientOrders { get; set; }
    }
}
