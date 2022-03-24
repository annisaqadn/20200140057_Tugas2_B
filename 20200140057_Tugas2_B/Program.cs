using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace _20200140057_Tugas2_B
{
    class Program
    {
        public void CreateTable()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("data source=FUADIN;database=Akyun;Integrated Security = TRUE");
                con.Open();

                SqlCommand cm = new SqlCommand("Create table Pembeli (ID_Pembeli char(6) not null primary key, Nama_Pembeli varchar(50), Alamat_Pembeli varchar (30), Jenis_Kelamin char(1), No_Telpon char(12))", con);
                cm.ExecuteNonQuery();

                Console.WriteLine("Tabel sukses dibuat!");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("Oops, sepertinya ada yang salah. " + e);
                Console.ReadKey();
            }
            finally
            {
                con.Close();
            }
        }
        static void Main(string[] args)
        {
            new Program().CreateTable();
        }
    }
}