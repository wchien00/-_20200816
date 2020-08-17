using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.Models
{
    public class DBtext
    {//參考 https://igouist.github.io/post/201912-aspnet-connect-db/
        private readonly string connStr = "Data Source=DESKTOP-676EIMH;Initial Catalog=Northwind;Integrated Security=True";

        public List<DBconnTest> GetCards() {
            List<DBconnTest> DBconnTests = new List<DBconnTest>();
            SqlConnection sqlConnection = new SqlConnection(connStr);
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [Order Details]");
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    DBconnTest DBconnTest = new DBconnTest
                    {
                        OrderID = reader.GetInt32(reader.GetOrdinal("OrderID")),
                        ProductID = reader.GetInt32(reader.GetOrdinal("ProductID")),
                        UnitPrice = reader.GetDecimal(reader.GetOrdinal("UnitPrice")),
                        Quantity = reader.GetInt16(reader.GetOrdinal("Quantity")),//參考 https://docs.microsoft.com/zh-tw/dotnet/api/system.data.datatablereader.getint16?view=netcore-3.1
                        Discount = reader.GetFloat(reader.GetOrdinal("Discount")),
                    };
                    DBconnTests.Add(DBconnTest);
                }
            }
            else
            {
                Console.WriteLine("資料庫為空！");
            }
            sqlConnection.Close();
            return DBconnTests;
        }
    }
}
