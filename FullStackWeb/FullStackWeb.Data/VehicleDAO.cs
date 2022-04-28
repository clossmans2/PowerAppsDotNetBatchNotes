using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStackWeb.Data {
    public class VehicleDAO : IVehicleDAO {
        //generally you would not do this in production code
        //this would be in a configuration/ enviroment file of some sort
        string connString = @"Data Source=LAPTOP-ADG811C2;Initial Catalog=MyDealership;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public int AddVehicle(Vehicle vehicle) {
            int id = -1;

            using (SqlConnection conn = new SqlConnection(connString)) {
                //string query = @"DECLARE @Id
                //                 INSERT INTO dbo.Inventory (Make, Model, Trim, Color, CurrentMileage, Year, Price, CreatedDate, HasWheels, ModifiedDate) 
                //                    VALUES (@make, @model, @trim, @color, @currentMileage, @year, @price, @createdDate, @hasWheels, @modifiedDate)
                //                 SET @Id = SCOPE_IDENTITY()
                //                 RETURN @Id";

                //to use a stored procedure
                SqlCommand cmd = new SqlCommand("[dbo].[InsertVehicleWithWheels]", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@make", vehicle.Make);
                cmd.Parameters.AddWithValue("@model", vehicle.Model);
                cmd.Parameters.AddWithValue("@trim", vehicle.Trim);
                cmd.Parameters.AddWithValue("@color", vehicle.Color);
                cmd.Parameters.AddWithValue("@currentMileage", vehicle.CurrentMileage);
                cmd.Parameters.AddWithValue("@year", vehicle.Year);
                cmd.Parameters.AddWithValue("@price", vehicle.Price);
                //cmd.Parameters.AddWithValue("@createdDate", vehicle.CreatedDate);
                //cmd.Parameters.AddWithValue("@hasWheels", vehicle.HasWheels);
                //cmd.Parameters.AddWithValue("@modifiedDate", vehicle.ModifiedDate);
                cmd.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output; //need to set the output parameter

                try {
                    conn.Open();
                    //id = (int)cmd.ExecuteScalar();
                    cmd.ExecuteNonQuery();
                    id = (int)cmd.Parameters["@id"].Value;
                    conn.Close();
                } catch (SqlException ex) {
                    Console.WriteLine("The person could not be added!\n" + ex.Message);
                }
            }
            
            return id;
        }

        public List<Vehicle> GetAllVehicles() {
            List<Vehicle> result = new List<Vehicle>();

            using (SqlConnection conn = new SqlConnection(connString)) {
                string query = "SELECT Id, Make, Model, Trim, Color, CurrentMileage, Year, Price, CreatedDate, HasWheels, ModifiedDate FROM dbo.Inventory;";
                SqlCommand cmd = new SqlCommand(query, conn);

                try {
                    conn.Open(); //the connection is not open until we run this
                    SqlDataReader reader = cmd.ExecuteReader(); //now we have sent the query

                    while (reader.Read()) {
                        var temp = new Vehicle(reader);

                        result.Add(temp);
                    }

                    conn.Close();
                } catch (SqlException ex) {
                    Console.WriteLine("The person could not be found!\n" + ex.Message);
                }
            }

            return result;
        }

        public Vehicle GetVehicle(int id) {
            Vehicle result = new Vehicle();

            using (SqlConnection conn = new SqlConnection(connString)) {
                //would want to set queries with user input up as a paramaterized statement to avoid sql injection attacks
                //parameterized queries are treated as plain text and are not interpreted/ parsed at all
                string query = "SELECT Id, Make, Model, Trim, Color, CurrentMileage, Year, Price, CreatedDate, HasWheels, ModifiedDate FROM dbo.Inventory WHERE Id = @Id;";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                try {
                    conn.Open(); //the connection is not open until we run this
                    SqlDataReader reader = cmd.ExecuteReader(); //now we have sent the query

                    if (reader.Read()) { //have to run atleast once. starts before the first returned column
                        //result.Id = Convert.ToInt32(reader["Id"]);
                        //result.Make = reader["Make"].ToString();
                        result = new Vehicle(reader);
                    }

                    conn.Close();
                } catch (SqlException ex) {
                    Console.WriteLine("The person could not be found!\n" + ex.Message);
                }
            }

            return result;
        }
    }
}
