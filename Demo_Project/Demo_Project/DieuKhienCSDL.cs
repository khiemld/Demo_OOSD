using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Demo_Project
{
    public class DieuKhienCSDL
    {
        string strConnectionString = "Data Source=LAPTOP-CI9259PR\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection conn = null; //Đối tượng kết nối 
        SqlCommand comm = null; //Đối tượng truy vấn và cập nhật vào SQL Serverwd
        SqlDataAdapter da = null; //Đối tượng đưa dữ liệu vào DataTable
    
        public SqlConnection getSqlConn //Lấy chuỗi kết nối
        {
            get
            {
                return conn;
            }
        }

        public DieuKhienCSDL() // Hàm khởi tạo: khởi tạo chuỗi kết nối và đối tượng truy vấn
        {
            conn = new SqlConnection(strConnectionString);
            comm = conn.CreateCommand();
        }

        private bool OpenConnection()
        {
            if (conn.State == ConnectionState.Closed)
            {
                try
                {
                    conn.Open();
                    return true;
                }
                catch (Exception ex)
                {
                   Console.WriteLine(ex.Message);
                    return false;
                }
            }
            return true;
        }

        private bool CloseConnection()
        {
            if (conn.State == ConnectionState.Open)
            {
                try
                {
                    conn.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
            return true;
        }

        public void closeConnectionManager() //Đóng kết nối
        {
            if ((conn.State == ConnectionState.Closed))
            {
                conn.Close();
            }
        }

        public bool authLogin(string username, string password)
        {
            try
            {
                if (OpenConnection())
                {

                    comm = new SqlCommand("Select u_email, u_email from dbo.Employee where u_email = @username and u_password = @password", conn);
                    comm.Parameters.AddWithValue("@username", username);
                    comm.Parameters.AddWithValue("@password", password);
                   
                    if (comm.ExecuteScalar() != null)
                    {
                        closeConnectionManager();
                        return true;
                    }

                    return false;
                }
                
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                CloseConnection();
            }

            return false;
        }

        public bool themSach(string tenSach, string moTa, string loaiSach, string ngayXB, string tenTG, string tenNXB, int giaSach, int soLuong)
        {
            try
            {
                if (OpenConnection())
                {
                    String query = "INSERT INTO dbo.Book(b_name, b_discription, b_category, b_price, b_author, b_date, b_publisher, b_quantity) VALUES (@name, @discription, @category, @price, @author, @date, @publisher, @quantity)";
                    comm = new SqlCommand("Select u_email, u_email from dbo.Employee where u_email = @username and u_password = @password", conn);
                    comm.Parameters.AddWithValue("@name", tenSach);
                    comm.Parameters.AddWithValue("@discription", moTa);
                    comm.Parameters.AddWithValue("@category", loaiSach);
                    comm.Parameters.AddWithValue("@price", giaSach);
                    comm.Parameters.AddWithValue("@author", tenTG);
                    comm.Parameters.AddWithValue("@publisher", tenNXB);
                    comm.Parameters.AddWithValue("@quantity", soLuong);
                    comm.Parameters.AddWithValue("@date", ngayXB);


                    if (comm.ExecuteNonQuery != null)
                    {
                        closeConnectionManager();
                        return true;
                    }

                    return false;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                CloseConnection();
            }

            return false;
        }
        

    }
}
