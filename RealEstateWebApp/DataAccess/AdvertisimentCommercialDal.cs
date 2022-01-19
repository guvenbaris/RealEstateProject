using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using RealEstateWebApp.DataAccess.Tools;
using RealEstateWebApp.ModelBase;
using RealEstateWebApp.Models;

namespace RealEstateWebApp.DataAccess
{
    public class AdvertisementCommercialDal : IOrmRepository<AdvertisimentCommercial>
    {


        private readonly UserDal _userDal;
        private readonly CommercialDal _commercialDal;

        public AdvertisementCommercialDal(UserDal userDal, CommercialDal commercialDal)
        {
            _userDal = userDal;
            _commercialDal = commercialDal;
        }

        public List<AdvertisimentCommercial> GetAll()
        {
            DataTools.DbConnection();
            string query = $"SELECT * FROM Advertisements  WHERE AdvertType = {Convert.ToInt32(AdvertType.Commercial)};";

            SqlCommand command = new SqlCommand(query, DataTools.Connection);

            DataTools.DbConnection();

            SqlDataReader reader = command.ExecuteReader();

            List<AdvertisimentCommercial> advertisimentCommercials = new List<AdvertisimentCommercial>();
            while (reader.Read())
            {
                AdvertisimentCommercial _advertisimentCommercial = new AdvertisimentCommercial
                {

                    AdvertisementId = Convert.ToInt32(reader["AdvertisementId"]),
                    PublishDate = Convert.ToDateTime(reader["PublishDate"]),
                    IsActive = Convert.ToBoolean(reader["IsActive"]),
                    Title = Convert.ToString(reader["Title"]),
                    Explanation = Convert.ToString(reader["Explanation"]),
                    User = _userDal.GetByUserId(Convert.ToInt32(reader["UserId"])),
                    AdvertType = Convert.ToInt32(reader["AdvertType"]).ToEnum<AdvertType>(),
                    Commercial =_commercialDal.GetCommercialById(Convert.ToInt32(reader["AdvertType"])),
                };
                advertisimentCommercials.Add(_advertisimentCommercial);
            }
            return advertisimentCommercials;
        }

        public AdvertisimentCommercial GetById(int id)
        {
            DataTools.DbConnection();
            string query = $"SELECT * FROM Advertisements WHERE AdvertisementId = {id};";

            SqlCommand command = new SqlCommand(query, DataTools.Connection);

            DataTools.DbConnection();

            SqlDataReader reader = command.ExecuteReader();

            AdvertisimentCommercial advertisimentCommercial = new AdvertisimentCommercial();
            while (reader.Read())
            {
                AdvertisimentCommercial _advertisimentCommercial = new AdvertisimentCommercial
                {

                    AdvertisementId = Convert.ToInt32(reader["AdvertisementId"]),
                    PublishDate = Convert.ToDateTime(reader["PublishDate"]),
                    IsActive = Convert.ToBoolean(reader["IsActive"]),
                    Title = Convert.ToString(reader["Title"]),
                    Explanation = Convert.ToString(reader["Explanation"]),
                    User = _userDal.GetByUserId(Convert.ToInt32(reader["UserId"])),
                    AdvertType = Convert.ToInt32(reader["AdvertType"]).ToEnum<AdvertType>(),
                    Commercial = _commercialDal.GetCommercialById(Convert.ToInt32(reader["AdvertType"])),

                };
                advertisimentCommercial = _advertisimentCommercial;
            }
            return advertisimentCommercial;
        }

        public void Update(AdvertisimentCommercial entity)
        {
            string query =
                $"UPDATE  Advertisements SET PublishDate = '{entity.PublishDate}',IsActive = '{entity.IsActive}',Title = '{entity.Title}'," +
                $"Explanation= '{entity.Explanation}',UserId ='{entity.User.UserId}'," +
                $"AdvertType = '{entity.AdvertTypeId}' WHERE AdvertisementId = {entity.AdvertisementId};";

            DataTools.DbConnection();

            SqlCommand command = new SqlCommand(query, DataTools.Connection);
            if (command.ExecuteNonQuery() > 0)
            {
                DataTools.DbDisconnection();
                Console.WriteLine("Advertisement Commercial updated");
            }
            DataTools.DbDisconnection();

        }

        public void Delete(AdvertisimentCommercial entity)
        {

            string query = $"DELETE FROM Advertisements WHERE AdvertisementId = {entity.AdvertisementId};";

            DataTools.DbConnection();

            SqlCommand command = new SqlCommand(query, DataTools.Connection);
            if (command.ExecuteNonQuery() > 0)
            {
                DataTools.DbDisconnection();
                Console.WriteLine("Advertisement Commercial deleted");
            }
            DataTools.DbDisconnection();
        }

        public void Add(AdvertisimentCommercial entity)
        {

            string query =
                $"INSERT INTO Advertisements(PublishDate,IsActive,Title,Explanation,UserId,AdvertType) " +
                $"VALUES('{entity.PublishDate}','{entity.IsActive}','{entity.Title}','{entity.Explanation}','{entity.User.UserId}'," +
                $"'{entity.AdvertTypeId}');";

            DataTools.DbConnection();

            SqlCommand command = new SqlCommand(query, DataTools.Connection);
            if (command.ExecuteNonQuery() > 0)
            {
                DataTools.DbDisconnection();
                Console.WriteLine("Advertisement Commercial added");
            }
            DataTools.DbDisconnection();
        }
    }
}
