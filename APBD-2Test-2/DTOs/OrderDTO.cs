using APBD_2Test_2.Models;
using System;

namespace APBD_2Test_2.DTOs
{
    public class OrderDTO
    {
        public DateTime OrderDate { get; set; }
        public DateTime CompletitionDate { get; set; }
        public string Comments { get; set; }

        public OrderDTO(ClientOrder clientOrder){
            OrderDate = clientOrder.OrderDate;
            CompletitionDate = clientOrder.CompletionDate;
            Comments = clientOrder.Comments;
        }

    }
}