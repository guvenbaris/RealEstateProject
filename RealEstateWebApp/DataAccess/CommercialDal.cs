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
    public class CommercialDal : IOrmRepository<Commercial>
    {

        private readonly AddressDal _addressDal;
        private readonly Address _address;

        public CommercialDal(AddressDal addressDal, Address address)
        {
            _addressDal = addressDal;
            _address = address;
        }

        public List<Commercial> GetAll()
        {
            DataTools.DbConnection();
            string query = "SELECT * FROM Residentials;";

            SqlCommand command = new SqlCommand(query, DataTools.Connection);

            DataTools.DbConnection();

            SqlDataReader reader = command.ExecuteReader();

            List<Commercial> commercials = new List<Commercial>();
            while (reader.Read())
            {
                Commercial commercial = new Commercial()
                {
                    CommercialId = Convert.ToInt32(reader["CommercialId"]),
                    Square = Convert.ToDouble(reader["Square"]),
                    Age = Convert.ToInt16(reader["Age"]),
                    FloorNumber = Convert.ToInt16(reader["FloorNumber"]),
                    Balcony = Convert.ToBoolean(reader["Balcony"]),
                    BuildingType = Convert.ToInt16(reader["BuildingType"]),
                    ResidentialType = Convert.ToInt32(reader["ResidentialType"]).ToEnum<ResidentialType>(),
                    SellType = Convert.ToInt32(reader["SellType"]).ToEnum<SellType>(),
                    Address = _addressDal.GetAddressById(Convert.ToInt32(_address.AddressId)),
                    Furnished = Convert.ToBoolean(reader["Furnished"]),
                    HeatingType = Convert.ToInt32(reader["HeatingType"]).ToEnum<HeatingType>()
                };
                commercials.Add(commercial);
            }
            reader.Close();
            DataTools.DbDisconnection();
            return commercials;
        }

        public Commercial GetById(int id)
        {

            DataTools.DbConnection();
            string query = $"SELECT * FROM Residentials WHERE CommercialId = {id};";

            SqlCommand command = new SqlCommand(query, DataTools.Connection);

            DataTools.DbConnection();

            SqlDataReader reader = command.ExecuteReader();

            Commercial commercial = new Commercial();
            while (reader.Read())
            {
                Commercial _commercial = new Commercial()
                {
                    CommercialId = Convert.ToInt32(reader["CommercialId"]),
                    Square = Convert.ToDouble(reader["Square"]),
                    Age = Convert.ToInt16(reader["Age"]),
                    FloorNumber = Convert.ToInt16(reader["FloorNumber"]),
                    Balcony = Convert.ToBoolean(reader["Balcony"]),
                    BuildingType = Convert.ToInt16(reader["BuildingType"]),
                    ResidentialType = Convert.ToInt32(reader["ResidentialType"]).ToEnum<ResidentialType>(),
                    SellType = Convert.ToInt32(reader["SellType"]).ToEnum<SellType>(),
                    Address = _addressDal.GetAddressById(Convert.ToInt32(_address.AddressId)),
                    Furnished = Convert.ToBoolean(reader["Furnished"]),
                    HeatingType = Convert.ToInt32(reader["HeatingType"]).ToEnum<HeatingType>()
                };
                commercial = _commercial;
            }
            reader.Close();
            DataTools.DbDisconnection();
            return commercial;

        }

        public void Update(Commercial entity)
        {
            string query =
                $"UPDATE  Commercials SET Square = '{entity.Square}',Age = '{entity.Age}',FloorNumber = '{entity.FloorNumber}'," +
                $"Balcony= '{entity.Balcony}',BuildingType = '{entity.BuildingType}',Furnished ='{entity.Furnished}',AddressId = '{entity.Address.AddressId}'," +
                $"HeatingType = '{entity.HeatingTypeId}',SellType = '{entity.SellTypeId}',ResidentialType = '{entity.ResidentialTypeId}' " +
                $"WHERE CommercialId = {entity.CommercialId};";

            DataTools.DbConnection();

            SqlCommand command = new SqlCommand(query, DataTools.Connection);
            if (command.ExecuteNonQuery() > 0)
            {
                DataTools.DbDisconnection();
                Console.WriteLine("Residential updated");
            }
            DataTools.DbDisconnection();
        }

        public void Delete(Commercial entity)
        {
            string query = $"DELETE FROM Residentials WHERE ResidentialId = {entity.CommercialId};";

            DataTools.DbConnection();

            SqlCommand command = new SqlCommand(query, DataTools.Connection);
            if (command.ExecuteNonQuery() > 0)
            {
                DataTools.DbDisconnection();
                Console.WriteLine("Residential deleted");
            }
            DataTools.DbDisconnection();
        }

        public void Add(Commercial entity)
        {
            string query =
                $"INSERT INTO Commercials(Square,Age,FloorNumber,Balcony,BuildingType,Furnished,AddressId,HeatingType,SellType,ResidentialType) " +
                $"VALUES('{entity.Square}','{entity.Age}','{entity.FloorNumber}','{entity.Balcony}','{entity.Furnished}'," +
                $"'{entity.Address.AddressId}','{entity.HeatingTypeId}','{entity.SellTypeId}','{entity.ResidentialTypeId}');";
            DataTools.DbConnection();

            SqlCommand command = new SqlCommand(query, DataTools.Connection);
            if (command.ExecuteNonQuery() > 0)
            {
                DataTools.DbDisconnection();
                Console.WriteLine("Residential updated");
            }
            DataTools.DbDisconnection();

        }
    }
}
