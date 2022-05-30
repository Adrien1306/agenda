using System;
using System.Collections.Generic;

namespace agenda.Models
{
    public partial class Appointment
    {
        public int Id { get; set; }
        public DateTime DateHour { get; set; }
        public string Subject { get; set; } = null!;
        public int IdCustomers { get; set; }
        public int IdBrokers { get; set; }

        public virtual Broker IdBrokersNavigation { get; set; } = null!;
        public virtual Customer IdCustomersNavigation { get; set; } = null!;
    }
}
