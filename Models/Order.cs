using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1ASP.NetCore.Models
{
    public class Order
    {
       
        [Key]
        public int ID { get; set; }
        public DateTime  OrderDate{ get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string CustomerEmail { get; set; }
        [Required]
        public int AmmountTickets { get; set; }
        [Required]
        public string MovieTitle { get; set; }
        [ForeignKey("Movie")]
        public int MovieID { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
