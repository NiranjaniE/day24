using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SBClient.Models
{
    public partial class SBclient
    {
        [Key]
        public int CustomerId { get; set; }
        public int AccountNumber { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public float CurrentBalance { get; set; }

    }
}
