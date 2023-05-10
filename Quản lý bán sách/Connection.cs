using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Quản_lý_bán_sách
{
    class Connection 
    {
        // Kết nối Database1.mdf
        private static string strConnect = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\84378\Downloads\CNPM\CNPM\Quản lý bán sách\Quản lý bán sách\Database1.mdf"";Integrated Security=True";
        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(strConnect);
        }
    }
}
