using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using RealEstateWebApp.DataAccess.Tools;
using RealEstateWebApp.Models;

namespace RealEstateWebApp.DataAccess
{
    public class AddressDal : IOrmRepository<Address>
    {
        private static AddressDal _Current { get; set; }

        public static AddressDal Current => _Current ?? (_Current = new AddressDal());

        public List<Address> GetAll()
        {
            DataTools.DbConnection();
            string query = $"SELECT * FROM Addresses;";

            SqlCommand command = new SqlCommand(query, DataTools.Connection);
            SqlDataReader reader = command.ExecuteReader();

            List<Address> addressList = new List<Address>();
            while (reader.Read())
            {
                Address address = new Address
                {
                    AddressId = Convert.ToInt32(reader["AddressId"]),
                    City = reader["City"].ToString(),
                    Street = reader["Street"].ToString(),
                    Description = reader["Description"].ToString(),
                    Country = reader["Country"].ToString(),
                    Town = reader["Town"].ToString()
                };
                addressList.Add(address);
            }
            reader.Close();
            DataTools.DbDisconnection();
            return addressList;
        }
        public Address GetById(int id)
        {
            DataTools.DbConnection();

            string query = $"SELECT * FROM Addresses WHERE AddressId = {id};";
           
            SqlCommand command = new SqlCommand(query,DataTools.Connection);

            SqlDataReader reader = command.ExecuteReader();

            Address _address = new Address();

            while (reader.Read())
            {
                Address address = new Address
                {
                    AddressId = Convert.ToInt32(reader["AddressId"]),
                    City = reader["City"].ToString(),
                    Street = reader["Street"].ToString(),
                    Description = reader["Description"].ToString(),
                    Country = reader["Country"].ToString(),
                    Town = reader["Town"].ToString()
                };
                _address = address;
            }
            reader.Close();
            DataTools.DbDisconnection();
            return _address;
        }
        public void Update(Address entity)
        {

            string query = $"UPDATE Addresses SET Country = '{entity.Country}'," +
                           $"City  ='{entity.City}',Town = '{entity.Town}',Street = '{entity.Street}',Description = '{entity.Description}'" +
                           $" WHERE AddressId = '{entity.AddressId}';";
                           

            DataTools.DbConnection();

            SqlCommand command = new SqlCommand(query, DataTools.Connection);

            if (command.ExecuteNonQuery() > 0)
            {
                DataTools.DbDisconnection();
                Console.WriteLine("Address updated");
            }
            DataTools.DbDisconnection();
        }
        public void Delete(Address entity)
        {
            string query = $"DELETE FROM Addresses WHERE AddressId = {entity.AddressId};";
            DataTools.DbConnection();

            SqlCommand command = new SqlCommand(query,DataTools.Connection);
            if (command.ExecuteNonQuery() > 0)
            {
                DataTools.DbDisconnection();
                Console.WriteLine("Address deleted!");
            }
            DataTools.DbDisconnection();
        }
        public void Add(Address entity)
        {
            string query = $"INSERT INTO Addresses(Country,City,Town,Street,Description)" +
                           $" VALUES('{entity.Country}','{entity.City}','{entity.Town}','{entity.Street}','{entity.Description}')";

            DataTools.DbConnection();
            
            SqlCommand command = new SqlCommand(query, DataTools.Connection);

            if (command.ExecuteNonQuery() > 0)
            {
                DataTools.DbDisconnection();
                Console.WriteLine("Address added");
            }
            DataTools.DbDisconnection();
            
        }
        public Address GetAddressById(int id)
        {

            //User veya başka Dal hizmet için yazılmıştır.
            string query = $"SELECT * FROM Addresses WHERE AddressId = {id};";

            SqlCommand command = new SqlCommand(query, DataTools.Connection);

            SqlDataReader reader = command.ExecuteReader();

            Address _address = new Address();

            while (reader.Read())
            {
                Address address = new Address
                {
                    AddressId = Convert.ToInt32(reader["AddressId"]),
                    City = reader["City"].ToString(),
                    Street = reader["Street"].ToString(),
                    Description = reader["Description"].ToString(),
                    Country = reader["Country"].ToString(),
                    Town = reader["Town"].ToString()
                };
                _address = address;
            }
            return _address;
        }
    }
}