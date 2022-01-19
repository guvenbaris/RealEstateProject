using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateWebApp.DataAccess.Tools;
using RealEstateWebApp.ModelBase;
using RealEstateWebApp.Models;

namespace RealEstateWebApp.DataAccess
{
    public class LandDal : IOrmRepository<Land>
    {
        private readonly AddressDal _addressDal;

        public LandDal(AddressDal addressDal)
        {
             _addressDal = addressDal;
        }
        public List<Land> GetAll()
        {
            DataTools.DbConnection();
            string query = "SELECT * FROM Lands;";

            SqlCommand command = new SqlCommand(query, DataTools.Connection);

            DataTools.DbConnection();

            SqlDataReader reader = command.ExecuteReader();

            List<Land> lands = new List<Land>();
            while (reader.Read())
            {
                Land land = new Land
                {

                    LandId = Convert.ToInt32(reader["LandId"]),
                    Square = Convert.ToDouble(reader["Square"]),
                    BlockNumber = Convert.ToInt32(reader["BlockNumber"]),
                    ParselNumber = Convert.ToInt32(reader["ParselNumber"]),
                    SquarePrice = Convert.ToSingle(reader["SquarePrice"]),
                    ZoningStatus = Convert.ToInt32(reader["ZoningStatus"]),
                    SellType = Convert.ToInt32(reader["SellType"]).ToEnum<SellType>(),
                    Address = _addressDal.GetAddressById(Convert.ToInt32(reader["AddressId"]))
                };
                lands.Add(land);
            }
            reader.Close();
            DataTools.DbDisconnection();
            return lands;
        }

        public Land GetById(int id)
        {
            DataTools.DbConnection();
            string query = $"SELECT * FROM Lands WHERE LandID = {id};";

            SqlCommand command = new SqlCommand(query, DataTools.Connection);

            DataTools.DbConnection();

            SqlDataReader reader = command.ExecuteReader();

            Land land = new Land();
            while (reader.Read())
            {
                Land _land = new Land
                {
                    LandId = Convert.ToInt32(reader["LandId"]),
                    Square = Convert.ToDouble(reader["Square"]),
                    BlockNumber = Convert.ToInt32(reader["BlockNumber"]),
                    ParselNumber = Convert.ToInt32(reader["ParselNumber"]),
                    SquarePrice = Convert.ToSingle(reader["SquarePrice"]),
                    ZoningStatus = Convert.ToInt32(reader["ZoningStatus"]),
                    SellType = Convert.ToInt32(reader["SellType"]).ToEnum<SellType>(),
                    Address = _addressDal.GetAddressById(Convert.ToInt32(reader["AddressId"]))
                };
                land = _land;
            }
            reader.Close();
            DataTools.DbDisconnection();
            return land;
        }
        public Land GetLandById(int id)
        {
            string query = $"SELECT * FROM Lands WHERE LandID = {id};";

            SqlCommand command = new SqlCommand(query, DataTools.Connection);

            DataTools.DbConnection();

            SqlDataReader reader = command.ExecuteReader();

            Land land = new Land();
            while (reader.Read())
            {
                Land _land = new Land
                {
                    LandId = Convert.ToInt32(reader["LandId"]),
                    Square = Convert.ToDouble(reader["Square"]),
                    BlockNumber = Convert.ToInt32(reader["BlockNumber"]),
                    ParselNumber = Convert.ToInt32(reader["ParselNumber"]),
                    SquarePrice = Convert.ToSingle(reader["SquarePrice"]),
                    ZoningStatus = Convert.ToInt32(reader["ZoningStatus"]),
                    SellType = Convert.ToInt32(reader["SellType"]).ToEnum<SellType>(),
                    Address = _addressDal.GetAddressById(Convert.ToInt32(reader["AddressId"]))
                };
                land = _land;
            }
            return land;
        }
        public void Update(Land entity)
        {
            string query =
                $"UPDATE  Lands SET Square = '{entity.Square}',BlockNumber = '{entity.BlockNumber}',ParselNumber = '{entity.ParselNumber}'," +
                $"SquarePrice= '{entity.SquarePrice}',ZoningStatus ='{entity.ZoningStatus}',AddressId = '{entity.Address.AddressId}',SellType = '{entity.SellTypeId}' " +
                $"WHERE LandId = {entity.LandId};";

            DataTools.DbConnection();

            SqlCommand command = new SqlCommand(query, DataTools.Connection);
            if (command.ExecuteNonQuery() > 0)
            {
                DataTools.DbDisconnection();
                Console.WriteLine("Land updated");
            }
            DataTools.DbDisconnection();
        }

        public void Delete(Land entity)
        {
            string query = $"DELETE FROM Lands WHERE LandId = {entity.LandId};";

            DataTools.DbConnection();

            SqlCommand command = new SqlCommand(query, DataTools.Connection);
            if (command.ExecuteNonQuery() > 0)
            {
                DataTools.DbDisconnection();
                Console.WriteLine("Land deleted");
            }
            DataTools.DbDisconnection();
        }

        public void Add(Land entity)
        {
            string query =
                $"INSERT INTO Lands (Square,BlockNumber,ParselNumber,SquarePrice, ZoningStatus,AddressId,SellType )" +
                $" VALUES ('{entity.Square}', '{entity.BlockNumber}','{entity.ParselNumber}'," +
                $"'{entity.SquarePrice}','{entity.ZoningStatus}', '{entity.Address.AddressId}', '{entity.SellTypeId}');";

                DataTools.DbConnection();

            SqlCommand command = new SqlCommand(query, DataTools.Connection);
            if (command.ExecuteNonQuery() > 0)
            {
                DataTools.DbDisconnection();
                Console.WriteLine("Land added");
            }
            DataTools.DbDisconnection();

        }
    }
}
