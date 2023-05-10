using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;    

namespace Quản_lý_bán_sách
{
    class Modify
    {
        public Modify()
        {

        }
        SqlCommand sqlCommand;
        SqlDataReader dataReader;
        public List<DanhSachTaiKhoan> DanhSachTaiKhoans(string query)
        {
            List<DanhSachTaiKhoan> taiKhoans = new List<DanhSachTaiKhoan>();
            using (SqlConnection sqlConnect = Connection.GetSqlConnection())
            {
                sqlConnect.Open();
                sqlCommand = new SqlCommand(query, sqlConnect); 
                dataReader = sqlCommand.ExecuteReader();    
                while (dataReader.Read())
                {
                    taiKhoans.Add(new DanhSachTaiKhoan(dataReader.GetString(0), dataReader.GetString(1)));
                }
                sqlConnect.Close(); 
            }
                return taiKhoans;
        }
        public void Command(String query)
        {
            using(SqlConnection sqlConnect = Connection.GetSqlConnection()) {
                sqlConnect.Open();
                sqlCommand = new SqlCommand(query,sqlConnect);
                sqlCommand.ExecuteNonQuery();

                sqlConnect.Close();
            }
        }
    }
}   
   
