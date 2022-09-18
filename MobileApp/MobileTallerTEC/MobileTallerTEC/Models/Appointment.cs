using System;
using System.Collections.Generic;

namespace MobileTallerTEC.Models
{
    public class Appointment
    {
        public string responsible { get; set; }
        public string assistant { get; set; }
        public string licensePlate { get; set; }
        public string service { get; set; }
        public string client { get; set; }
        public string office { get; set; }
        public string date { get; set; }
        public List<Replacements> replacements { get; set; }

    }

    public class Replacements
    {
        public string LicensePlate { get; set; }
        public string Replacement { get; set; }

    }
}
