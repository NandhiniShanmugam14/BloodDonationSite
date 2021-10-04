using System;
using System.Collections.Generic;

#nullable disable

namespace BloodDonarApplication.BloodDonationModal
{
    public partial class Blooddonationcamp
    {
        public int Id { get; set; }
        public DateTime Dateofcamp { get; set; }
        public string Venue { get; set; }
        public string Timing { get; set; }
    }
}
