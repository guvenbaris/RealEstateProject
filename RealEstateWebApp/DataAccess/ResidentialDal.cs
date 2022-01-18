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
    public class ResidentialDal : IOrmRepository<Residential>
    {
        private readonly AddressDal _addressDal;
        private readonly Address _address;

        public ResidentialDal(AddressDal addressDal, Address address)
        {
            _addressDal = addressDal;
            _address = address;
        }

        public List<Residential> GetAll()
        {
            DataTools.DbConnection();
            string query = "SELECT * FROM Residentials;";

            SqlCommand command = new SqlCommand(query, DataTools.Connection);

            DataTools.DbConnection();

            SqlDataReader reader = command.ExecuteReader();

            List<Residential> residentials = new List<Residential>();
            while (reader.Read())
            {
                Residential residential = new Residential
                {
                    ResidentialId = Convert.ToInt32(reader["ResidentialId"]),
                    Square = Convert.ToDouble(reader["Square"]),
                    Age = Convert.ToInt16(reader["Age"]),
                    FloorNumber = Convert.ToInt16(reader["FloorNumber"]),
                    Balcony = Convert.ToBoolean(reader["Balcony"]),
                    Furnished = Convert.ToBoolean(reader["Furnished"]),
                    HeatingType = Convert.ToInt32(reader["HeatingType"]).ToEnum<HeatingType>(),
                    ResidentialType = Convert.ToInt32(reader["ResidentialType"]).ToEnum<ResidentialType>(),
                    SellType = Convert.ToInt32(reader["SellType"]).ToEnum<SellType>(),
                    Address = _addressDal.GetAddressById(Convert.ToInt32(_address.AddressId))
                };
                residentials.Add(residential);
            }
            reader.Close();
            DataTools.DbDisconnection();
            return residentials;

        }

    public Residential GetById(int id)
        {
            DataTools.DbConnection();
            string query = $"SELECT * FROM Residentials WHERE ResidentialId = {id};";

            SqlCommand command = new SqlCommand(query, DataTools.Connection);

            DataTools.DbConnection();

            SqlDataReader reader = command.ExecuteReader();

            Residential residential = new Residential();
            while (reader.Read())
            {
                Residential _residential = new Residential
                {
                    ResidentialId = Convert.ToInt32(reader["ResidentialId"]),
                    Square = Convert.ToDouble(reader["Square"]),
                    Age = Convert.ToInt16(reader["Age"]),
                    FloorNumber = Convert.ToInt16(reader["FloorNumber"]),
                    Balcony = Convert.ToBoolean(reader["Balcony"]),
                    Furnished = Convert.ToBoolean(reader["Furnished"]),
                    HeatingType = Convert.ToInt32(reader["HeatingType"]).ToEnum<HeatingType>(),
                    ResidentialType = Convert.ToInt32(reader["ResidentialType"]).ToEnum<ResidentialType>(),
                    SellType = Convert.ToInt32(reader["SellType"]).ToEnum<SellType>(),
                    Address = _addressDal.GetAddressById(Convert.ToInt32(_address.AddressId))
                };
                residential = _residential;
            }
            reader.Close();
            DataTools.DbDisconnection();
            return residential;
        }

        public void Update(Residential entity)
        {
            string query =
                $"UPDATE  Residentials SET Square = '{entity.Square}',Age = '{entity.Age}',FloorNumber = '{entity.FloorNumber}'," +
                $"Balcony= '{entity.Balcony}',Furnished ='{entity.Furnished}',AddressId = '{entity.Address.AddressId}'," +
                $"HeatingType = '{entity.HeatingTypeId}',SellType = '{entity.SellTypeId}',ResidentialType = '{entity.SellTypeId}' " +
                $"WHERE ResidentialId = {entity.ResidentialId};";

            DataTools.DbConnection();

            SqlCommand command = new SqlCommand(query, DataTools.Connection);
            if (command.ExecuteNonQuery() > 0)
            {
                DataTools.DbDisconnection();
                Console.WriteLine("Residential updated");
            }
            DataTools.DbDisconnection();


        }

        public void Delete(Residential entity)
        {

            string query = $"DELETE FROM Residentials WHERE ResidentialId = {entity.ResidentialId};";

            DataTools.DbConnection();

            SqlCommand command = new SqlCommand(query, DataTools.Connection);
            if (command.ExecuteNonQuery() > 0)
            {
                DataTools.DbDisconnection();
                Console.WriteLine("Residential deleted");
            }
            DataTools.DbDisconnection();
        }

        public void Add(Residential entity)
        {
            string query =
                $"INSERT INTO Residentials(Square,Age,FloorNumber,Balcony,Furnished,AddressId,HeatingType,SellType,ResidentialType) " +
                $"VALUES('{entity.Square}','{entity.Age}','{entity.FloorNumber}','{entity.Balcony}','{entity.Furnished}'," +
                $"'{entity.Address.AddressId}','{entity.HeatingTypeId}','{entity.SellTypeId}','{entity.ResidentialTypeId}');";

            DataTools.DbConnection();

            SqlCommand command = new SqlCommand(query, DataTools.Connection);
            if (command.ExecuteNonQuery() > 0)
            {
                DataTools.DbDisconnection();
                Console.WriteLine("Residential added");
            }
            DataTools.DbDisconnection();
        }
    }
}
