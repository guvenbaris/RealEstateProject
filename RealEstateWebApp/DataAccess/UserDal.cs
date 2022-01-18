﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateWebApp.DataAccess.Tools;
using RealEstateWebApp.Models;

namespace RealEstateWebApp.DataAccess
{
    public class UserDal 
    {
        private readonly Address _address;
        private readonly AddressDal _addressDal;

        public UserDal(AddressDal addressDal, Address address)
        {
            _addressDal = addressDal;
            _address = address;
        }

        public List<User> GetAll()
        {
            DataTools.DbConnection();

            string query = "SELECT * FROM USERS;";

            SqlCommand command = new SqlCommand(query,DataTools.Connection);

            SqlDataReader reader = command.ExecuteReader();

            List<User> users = new List<User>();
            while (reader.Read())
            {
                User user = new User
                {
                    UserId = Convert.ToInt32(reader["UserId"]),
                    Email = reader["Email"].ToString(),
                    FullName = reader["FullName"].ToString(),
                    Password = reader["Password"].ToString(),
                    PhoneNumber = reader["PhoneNumber"].ToString(),
                    ProfilePicUrl = reader["ProfilePicUrl"].ToString(),
                    Address = _addressDal.GetAddressById(Convert.ToInt32(reader["AddressId"]))
                };
                users.Add(user); 
            }
            reader.Close();
            DataTools.DbDisconnection();
            return users;
        }

        public User GetById(int id)
        {
            DataTools.DbConnection();

            string query = $"SELECT * FROM USERS WHERE UserId = {id};";

            SqlCommand command = new SqlCommand(query, DataTools.Connection);

            SqlDataReader reader = command.ExecuteReader();

            User user = new User();
            while (reader.Read())
            {
                User _user = new User
                {
                    UserId = Convert.ToInt32(reader["UserId"]),
                    Email = reader["Email"].ToString(),
                    FullName = reader["FullName"].ToString(),
                    Password = reader["Password"].ToString(),
                    PhoneNumber = reader["PhoneNumber"].ToString(),
                    ProfilePicUrl = reader["ProfilePicUrl"].ToString(),
                    Address = _addressDal.GetAddressById(Convert.ToInt32(reader["AddressId"]))
                };
                user = _user;
            }
            reader.Close();
            DataTools.DbDisconnection();
            return user;




        }

        public void Update(User entity)
        {
            string query = $"UPDATE USERS SET FullName='{entity.FullName}',Email = '{entity.Email}'," +
                           $"Password ='{entity.Password}',PhoneNumber = '{entity.PhoneNumber}'," +
                           $"ProfilePicUrl = '{entity.ProfilePicUrl}',AddressId = '{_address.AddressId}';";

            DataTools.DbConnection();

            SqlCommand command = new SqlCommand(query, DataTools.Connection);
            if (command.ExecuteNonQuery() > 0)
            {
                DataTools.DbDisconnection();
                Console.WriteLine("User updated");
            }
            DataTools.DbDisconnection();
        }

        public void Delete(User entity)
        {
            string query = $"DELETE FROM USERS WHERE UserId = {entity.UserId};";

            DataTools.DbConnection();

            SqlCommand command = new SqlCommand(query, DataTools.Connection);
            if (command.ExecuteNonQuery() > 0)
            {
                DataTools.DbDisconnection();
                Console.WriteLine("User deleted");
            }
            DataTools.DbDisconnection();
        }

        public void Add(User entity)
        {
            string query = $"INSERT INTO USERS(FullName,Email,Password,PhoneNumber,ProfilePicUrl,AddressId)" +
                           $"VALUES('{entity.FullName}','{entity.Email}','{entity.Password}','{entity.PhoneNumber}'," +
                           $"'{entity.ProfilePicUrl}','{_address.AddressId}');";
            DataTools.DbConnection();

            SqlCommand command = new SqlCommand(query, DataTools.Connection);
            if (command.ExecuteNonQuery() > 0 )
            {
                DataTools.DbDisconnection();
                Console.WriteLine("User added");
            }
            DataTools.DbDisconnection();
        }
    }
}