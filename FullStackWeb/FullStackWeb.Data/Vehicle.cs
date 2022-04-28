using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStackWeb.Data {
    public class Vehicle {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Trim { get; set; }
        public string Color { get; set; }
        public int CurrentMileage { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public int HasWheels { get; set; }
        public DateTime ModifiedDate { get; set; }

        public Vehicle() {
            Id = 0;
            Make = "";
            Model = "";
            Trim = "";
            Color = "";
            CurrentMileage = 0;
            Year = 0;
            Price = 0.0;
            CreatedDate = DateTime.Now;
            HasWheels = 0;
            ModifiedDate = DateTime.Now;
        }

        //moved to constructor to remove clutter in my other code and for re-useability 
        public Vehicle(SqlDataReader reader) {
            Id = Convert.ToInt32(reader["Id"] ?? 0);
            Make = reader["Make"].ToString() ?? "";
            Model = reader["Model"].ToString() ?? "";
            Trim = reader["Trim"].ToString() ?? "";
            Color = reader["Color"].ToString() ?? "";
            CurrentMileage = Convert.ToInt32(reader["CurrentMileage"]);
            Year = Convert.ToInt32(reader["Year"] ?? 0);
            Price = Convert.ToDouble(reader["Price"] ?? 0.0);
            CreatedDate = Convert.ToDateTime(reader["CreatedDate"] ?? DateTime.Now);
            HasWheels = Convert.ToInt32(reader["HasWheels"] ?? 0);
            ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"] ?? DateTime.Now);
        }
        public override string ToString() {
            return $"[Vehicle {Id}, {Make}, {Model}, {Trim}, {Color}, {CurrentMileage}, {Year}, {Price}, {CreatedDate}, {HasWheels}, {ModifiedDate}]";
        }
    }
}
