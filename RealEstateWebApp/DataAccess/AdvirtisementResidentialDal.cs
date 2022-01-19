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
    public class AdvirtisementResidentialDal : IOrmRepository<AdvertisimentResedential>
    {

        private readonly UserDal _userDal;
        private readonly ResidentialDal _residentialDal;

        public AdvirtisementResidentialDal(ResidentialDal residentialDal, UserDal userDal)
        {
            _residentialDal = residentialDal;
            _userDal = userDal;
        }

        public List<AdvertisimentResedential> GetAll()
        {
            DataTools.DbConnection();
            string query = "SELECT * FROM Advertisements;";

            SqlCommand command = new SqlCommand(query, DataTools.Connection);

            DataTools.DbConnection();

            SqlDataReader reader = command.ExecuteReader();

            List<AdvertisimentResedential> advertisimentResedentials = new List<AdvertisimentResedential>();
            while (reader.Read())
            {
                AdvertisimentResedential advertisimentResedential = new AdvertisimentResedential
                {

                    AdvertisementId = Convert.ToInt32(reader["AdvertisementId"]),
                    PublishDate = Convert.ToDateTime(reader["PublishDate"]),
                    IsActive = Convert.ToBoolean(reader["IsActive"]),
                    Title = Convert.ToString(reader["Title"]),
                    Explanation = Convert.ToString(reader["Explanation"]),
                    User = _userDal.GetByUserId(Convert.ToInt32(reader["UserId"])),
                    Residential = _residentialDal.GetByResidentialId(Convert.ToInt32(reader["AdvertType"])),
                };
                advertisimentResedentials.Add(advertisimentResedential);
                
            }
            return advertisimentResedentials;
        }

        public AdvertisimentResedential GetById(int id)
        {
            DataTools.DbConnection();
            string query = $"SELECT * FROM Advertisements WHERE AdvertisementId = {id};";

            SqlCommand command = new SqlCommand(query, DataTools.Connection);

            DataTools.DbConnection();

            SqlDataReader reader = command.ExecuteReader();

            AdvertisimentResedential advertisimentResedential = new AdvertisimentResedential();
            while (reader.Read())
            {
                AdvertisimentResedential _advertisimentResedential = new AdvertisimentResedential
                {
                    AdvertisementId = Convert.ToInt32(reader["AdvertisementId"]),
                    PublishDate = Convert.ToDateTime(reader["PublishDate"]),
                    IsActive = Convert.ToBoolean(reader["IsActive"]),
                    Title = Convert.ToString(reader["Title"]),
                    Explanation = Convert.ToString(reader["Explanation"]),
                    User = _userDal.GetByUserId(Convert.ToInt32(reader["UserId"])),
                    Residential = _residentialDal.GetByResidentialId(Convert.ToInt32(reader["AdvertType"])),
                };
                advertisimentResedential = _advertisimentResedential;
            }
            return advertisimentResedential;
        }

        public void Update(AdvertisimentResedential entity)
        {
            string query =
                $"UPDATE  Advertisements SET PublishDate = '{entity.PublishDate}',IsActive = '{entity.IsActive}',Title = '{entity.Title}'," +
                $"Explanation= '{entity.Explanation}',UserId ='{entity.User.UserId}',BuildingType = '{entity.BuildingType}'," +
                $"AdvertType = '{entity.AdvertTypeId}' WHERE AdvertisementId = {entity.AdvertisementId};";


            DataTools.DbConnection();

            SqlCommand command = new SqlCommand(query, DataTools.Connection);
            if (command.ExecuteNonQuery() > 0)
            {
                DataTools.DbDisconnection();
                Console.WriteLine("Advertisement Residential updated");
            }
            DataTools.DbDisconnection();
        }
        public void Delete(AdvertisimentResedential entity)
        {
            string query = $"DELETE FROM Advertisements WHERE AdvertisementId = {entity.AdvertisementId};";

            DataTools.DbConnection();

            SqlCommand command = new SqlCommand(query, DataTools.Connection);
            if (command.ExecuteNonQuery() > 0)
            {
                DataTools.DbDisconnection();
                Console.WriteLine("Advertisement Residential deleted");
            }
            DataTools.DbDisconnection();
        }

        public void Add(AdvertisimentResedential entity)
        {

            string query =
                $"INSERT INTO AdvertisimentResedentials(PublishDate,IsActive,Title,Explanation,UserId,BuildingType,AdvertType) " +
                $"VALUES('{entity.PublishDate}','{entity.IsActive}','{entity.Title}','{entity.Explanation}','{entity.User.UserId}'," +
                $"'{entity.BuildingType}','{entity.AdvertTypeId}';";

            DataTools.DbConnection();

            SqlCommand command = new SqlCommand(query, DataTools.Connection);
            if (command.ExecuteNonQuery() > 0)
            {
                DataTools.DbDisconnection();
                Console.WriteLine("Advertisement Residential added");
            }
            DataTools.DbDisconnection();
        }
    }
}
