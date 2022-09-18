using System;
using System.Collections.Generic;
using System.Text;

namespace MobileTallerTEC.Models
{
    public class Bill
    {
        public string service { get; set; }
        public int cost { get; set; }
        public string mecanic { get; set; }
        public string date { get; set; }

        public string licensePlate { get; set; }
    }
}
