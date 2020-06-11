using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AwardDao : IAwardDao
    {
        private string _connection;
        public AwardDao()
        {
            _connection = @"Data Source=.\SQLEXPRESS;Initial Catalog=Task3_Ado;Integrated Security=True";
        }
        public bool AddAward(Award award)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(_connection);
                sqlConnection.Open();
                string insertSqlString = "Insert into Awards(Title) Values('{0}')";
                insertSqlString = string.Format(insertSqlString, award.Title);
                SqlCommand sqlCommand = new SqlCommand(insertSqlString, sqlConnection);
                sqlCommand.ExecuteNonQuery();
                return true;

            }
            catch
            {
                return false;
            }
        }

        public List<Award> GetAwards()
        {

            List<Award> awards = new List<Award>();
            using (SqlConnection sqlConnection = new SqlConnection(_connection))
            {
                sqlConnection.Open();
                string selSqlString = "Select * from Awards";
                SqlCommand sqlCommand = new SqlCommand(selSqlString, sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    awards.Add(new Award(Convert.ToInt32(sqlDataReader["ID"].ToString()), sqlDataReader["Title"].ToString()));
                }
                return awards;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(_connection);
                sqlConnection.Open();
                string delSqlString = "Delete from Awards Where ID = {0}";
                delSqlString = string.Format(delSqlString, id);
                SqlCommand sqlCommand = new SqlCommand(delSqlString, sqlConnection);
                sqlCommand.ExecuteNonQuery();
                return true;

            }
            catch
            {
                return false;
            }
        }

        public bool AddAwardForUser(int idAward, int idUser)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(_connection);
                sqlConnection.Open();
                string insSqlString = "Insert into Users_Awards(UserID, AwardID) values({0}, {1})";
                insSqlString = String.Format(insSqlString, idUser, idAward);
                SqlCommand sqlCommand = new SqlCommand(insSqlString, sqlConnection);
                sqlCommand.ExecuteNonQuery();
                return true;

            }
            catch
            {
                return false;
            }
        }
    }
}
