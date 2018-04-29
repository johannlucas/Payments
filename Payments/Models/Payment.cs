using System;

namespace Payments.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Amount { get; set; }
        public bool Paid { get; set; }
        public string Comments { get; set; }
        public DateTime Payday { get; set; }
    }
}
