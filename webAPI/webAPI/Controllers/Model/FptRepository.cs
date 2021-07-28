using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace webAPI.Controllers.Model
{
    public class FptRepository
    {
        private string connectionString;
        public FptRepository()
        {
            connectionString = @"Persist Security Info=False; TrustServerCertificate=True;User ID=SysLogin;password=123;Initial Catalog=TestFitPro; Data Source =servidor_s; Connection Timeout= 100000;";
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }
        public void Add(Fpt ftp)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"INSERT INTO Fpt (name,phone,email,note ) VALUES (@name,@phone,@email,@note)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, ftp);
            }
        }

        public IEnumerable<Fpt> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT * FROM Fpt";
                dbConnection.Open();
                return dbConnection.Query<Fpt>(sQuery);
            }

        }
        public Fpt GetById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT * FROM Fpt where FptId = @Id";
                dbConnection.Open();
                return dbConnection.Query<Fpt>(sQuery, new { Id = id }).FirstOrDefault();
            }

        }
        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"DELETE FROM Fpt where FptId = @Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { Id = id });
            }

        }

        public void Update(Fpt ftp)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"UPDATE Products SET name=@name, phone=@phone, email=@email, note=@note where FptId=@FptId";
                dbConnection.Open();
                dbConnection.Execute(sQuery, ftp);
            }

        }
    }
}
