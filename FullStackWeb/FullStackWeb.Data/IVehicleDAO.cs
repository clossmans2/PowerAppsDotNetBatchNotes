using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStackWeb.Data {
    public interface IVehicleDAO {
        public List<Vehicle> GetAllVehicles();
        public Vehicle GetVehicle(int id);
        public int AddVehicle(Vehicle vehicle);
    }
}
