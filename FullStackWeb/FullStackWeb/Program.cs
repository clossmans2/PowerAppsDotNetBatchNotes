using FullStackWeb.Data;
using System;

namespace FullStackWeb {
    public class Program {
        public static void Main(string[] args) {
            //DAO = Data Access Object
            //Reposotory
            //both accomplish the same thing
            IVehicleDAO dao = new VehicleDAO();

            //Vehicle car1 = dao.GetVehicle(1005);
            //Vehicle car2 = dao.GetVehicle(1011);
            //Vehicle car3 = dao.GetVehicle(1002);

            //Console.WriteLine(car1);
            //Console.WriteLine(car2);
            //Console.WriteLine(car3);

            Vehicle newVehicle = new Vehicle();
            newVehicle.Make = "Mazda";
            newVehicle.Model = "RX-8";
            newVehicle.Year = 2012;
            newVehicle.Trim = "Sport";
            newVehicle.Color = "Blue";
            newVehicle.CurrentMileage = 25045;
            newVehicle.Price = 24000;
            newVehicle.CreatedDate = DateTime.Now;
            newVehicle.HasWheels = 1;
            newVehicle.ModifiedDate = DateTime.Now;

            int newId = dao.AddVehicle(newVehicle);
            Console.WriteLine(newId);

            List<Vehicle> vehicles = dao.GetAllVehicles();

            foreach (var car in vehicles) {
                Console.WriteLine(car);
            }
        }
    }
}