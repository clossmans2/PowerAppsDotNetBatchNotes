using System;
using System.Collections.Generic;

namespace EFDemo
{
    public partial class Inventory
    {
        public int Id { get; set; }
        public string Make { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string Trim { get; set; } = null!;
        public string Color { get; set; } = null!;
        public int CurrentMileage { get; set; }
        public int Year { get; set; }
        public decimal? Price { get; set; }
        public byte? HasWheels { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
