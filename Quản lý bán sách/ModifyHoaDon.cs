using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Quản_lý_bán_sách
{
    class ModifyHoaDon
    {
        public ModifyHoaDon()
        {

        }
        SqlDataAdapter dataAdapter;
        SqlCommand sqlcommand;
        // Trả về bảng dữ liệu
        public DataTable Table(String query)
        {
            DataTable dataTable = new DataTable();
            using(SqlConnection sqlConnection = ConnectDatabase2.GetSqlConnection())
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter(query, sqlConnection);
                dataAdapter.Fill(dataTable);
                sqlConnection.Close();
            }
            return dataTable;
        }
        //Thêm sửa xóa hóa đơn
        public void Command(string query)
        {
            using(SqlConnection sqlConnection = ConnectDatabase2.GetSqlConnection())
            {
                sqlConnection.Open();
                sqlcommand = new SqlCommand(query, sqlConnection);
                sqlcommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }
    }
    


}
