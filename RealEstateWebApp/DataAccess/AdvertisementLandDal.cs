using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using RealEstateWebApp.DataAccess.Tools;
using RealEstateWebApp.ModelBase;
using RealEstateWebApp.Models;

namespace RealEstateWebApp.DataAccess
{
    public class AdvertisementLandDal : IOrmRepository<AdvertisimentLand>
    {


        private readonly UserDal _userDal;
        private readonly LandDal _landDal;

        public AdvertisementLandDal(LandDal landDal, UserDal userDal)
        {
            _landDal = landDal;
            _userDal = userDal;
        }

        public List<AdvertisimentLand> GetAll()
        {
            DataTools.DbConnection();
            string query = $"SELECT * FROM AdvertisementLands;";

            SqlCommand command = new SqlCommand(query, DataTools.Connection);

            DataTools.DbConnection();

            SqlDataReader reader = command.ExecuteReader();

            List<AdvertisimentLand> advertisimentLands = new List<AdvertisimentLand>();
            while (reader.Read())
            {
                AdvertisimentLand _advertisimentLand = new AdvertisimentLand
                {
                    AdvertisementId = Convert.ToInt32(reader["AdvertisementId"]),
                    PublishDate = Convert.ToDateTime(reader["PublishDate"]),
                    IsActive = Convert.ToBoolean(reader["IsActive"]),
                    Title = Convert.ToString(reader["Title"]),
                    Explanation = Convert.ToString(reader["Explanation"]),
                    User = _userDal.GetByUserId(Convert.ToInt32(reader["UserId"])),
                    AdvertType = Convert.ToInt32(reader["AdvertType"]).ToEnum<AdvertType>(),
                    Land = _landDal.GetLandById(Convert.ToInt32(reader["LandId"])),
                };
                advertisimentLands.Add(_advertisimentLand);
            }
            return advertisimentLands;
        }

        public AdvertisimentLand GetById(int id)
        {
            DataTools.DbConnection();
            string query = $"SELECT * FROM AdvertisementLands WHERE AdvertisementId = {id};";

            SqlCommand command = new SqlCommand(query, DataTools.Connection);

            DataTools.DbConnection();

            SqlDataReader reader = command.ExecuteReader();

            AdvertisimentLand advertisimentLand = new AdvertisimentLand();
            while (reader.Read())
            {
                AdvertisimentLand _advertisimentLand = new AdvertisimentLand
                {

                    AdvertisementId = Convert.ToInt32(reader["AdvertisementId"]),
                    PublishDate = Convert.ToDateTime(reader["PublishDate"]),
                    IsActive = Convert.ToBoolean(reader["IsActive"]),
                    Title = Convert.ToString(reader["Title"]),
                    Explanation = Convert.ToString(reader["Explanation"]),
                    User = _userDal.GetByUserId(Convert.ToInt32(reader["UserId"])),
                    AdvertType = Convert.ToInt32(reader["AdvertType"]).ToEnum<AdvertType>(),
                    Land = _landDal.GetLandById(Convert.ToInt32(reader["LandId"])),
                };
                advertisimentLand = _advertisimentLand;
            }
            return advertisimentLand;
        }

        public void Update(AdvertisimentLand entity)
        {

            string query =
                $"UPDATE  AdvertisementLands SET PublishDate = '{entity.PublishDate}',IsActive = '{entity.IsActive}',Title = '{entity.Title}'," +
                $"Explanation= '{entity.Explanation}',UserId ='{entity.User.UserId}',"+
                $"AdvertType = '{entity.AdvertTypeId}',LandId='{entity.Land.LandId}' WHERE AdvertisementId = {entity.AdvertisementId};";


            DataTools.DbConnection();

            SqlCommand command = new SqlCommand(query, DataTools.Connection);
            if (command.ExecuteNonQuery() > 0)
            {
                DataTools.DbDisconnection();
                Console.WriteLine("Advertisement Land updated");
            }
            DataTools.DbDisconnection();

        }

        public void Delete(AdvertisimentLand entity)
        {
            string query = $"DELETE FROM AdvertisementLands WHERE AdvertisementId = {entity.AdvertisementId};";

            DataTools.DbConnection();

            SqlCommand command = new SqlCommand(query, DataTools.Connection);
            if (command.ExecuteNonQuery() > 0)
            {
                DataTools.DbDisconnection();
                Console.WriteLine("Advertisement Land deleted");
            }
            DataTools.DbDisconnection();
        }

        public void Add(AdvertisimentLand entity)
        {
            string query =
                $"INSERT INTO AdvertisementLands(PublishDate,IsActive,Title,Explanation,UserId,AdvertType,LandId) " +
                $"VALUES('{entity.PublishDate}','{entity.IsActive}','{entity.Title}','{entity.Explanation}','{entity.User.UserId}'," +
                $"'{entity.AdvertTypeId}','{entity.Land.LandId}');";

            DataTools.DbConnection();

            SqlCommand command = new SqlCommand(query, DataTools.Connection);
            if (command.ExecuteNonQuery() > 0)
            {
                DataTools.DbDisconnection();
                Console.WriteLine("Advertisement Land added");
            }
            DataTools.DbDisconnection();
        }
    }
}
