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

                SqlCommand cm = new SqlCommand("Create table Pembeli (ID_Pembeli char(6) not null primary key, Nama_Pembeli varchar(50), Alamat_Pembeli varchar (30), Jenis_Kelamin char(1), No_Telpon char(12))"
                    + "Create table Pegawai (ID_Pegawai char(5) not null primary key, Nama_Pegawai varchar(50), Alamat_Pegawai varchar (30), No_Telpon char(12), Jenis_Kelamin char(1))" +
                    "Create table Obat (ID_Obat char(6) not null primary key, Nama_Obat varchar(30), Jenis_Obat varchar (20), Harga_Obat varchar (30), Stok_Obat varchar (5), ID_Pegawai char(5) FOREIGN KEY REFERENCES Pegawai(ID_Pegawai))"
                    + "Create table Supplier (ID_Supplier char(3) not null primary key, Nama_Supplier varchar(50), Alamat_Supplier varchar (30), No_Telpon char(12))" +
                    "Create table Transaksi (ID_Transaksi char(5) not null primary key, ID_Pembeli char (6) FOREIGN KEY REFERENCES Pegawai(ID_Pegawai), ID_Obat char(6) FOREIGN KEY REFERENCES Obat(ID_Obat), Qty varchar(5), Tgl_Pembelian datetime)"
                    + "Create table Supply (ID_Supply char(4) not null primary key, ID_Supplier char (3) FOREIGN KEY REFERENCES Supplier(ID_Supplier), ID_Obat char(6) FOREIGN KEY REFERENCES Obat(ID_Obat), Qty varchar(5), Tgl_Supply datetime)", con);
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
        public void InsertData()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("data source=FUADIN;database=Akyun;Integrated Security = TRUE");
                con.Open();

                SqlCommand cm = new SqlCommand("insert into Pembeli (ID_Pembeli, Nama_Pembeli, Alamat_Pembeli, Jenis_Kelamin, No_Telpon) values ('PBL001','Tiara Sekarsini','Sumedang','P','082722827291')" +
                    "insert into Pembeli (ID_Pembeli, Nama_Pembeli, Alamat_Pembeli, Jenis_Kelamin, No_Telpon) values ('PBL002','Zahwa Ladya','Makassar','P','081638494733')" +
                    "insert into Pembeli (ID_Pembeli, Nama_Pembeli, Alamat_Pembeli, Jenis_Kelamin, No_Telpon) values ('PBL003','Savana Rizqi','Pati','P','081642738398')" +
                    "insert into Pembeli (ID_Pembeli, Nama_Pembeli, Alamat_Pembeli, Jenis_Kelamin, No_Telpon) values ('PBL004','Zahran Rafif','Yogyakarta','L','082663803826')" +
                    "insert into Pembeli (ID_Pembeli, Nama_Pembeli, Alamat_Pembeli, Jenis_Kelamin, No_Telpon) values ('PBL005','Alam Nurcahaya','Sleman','L','081648949437')" +
                    "insert into Pegawai (ID_Pegawai, Nama_Pegawai, Alamat_Pegawai, No_Telpon, Jenis_Kelamin) values ('PGW01','Belinda Nur','Yogyakarta','082722536471','P')" +
                    "insert into Pegawai (ID_Pegawai, Nama_Pegawai, Alamat_Pegawai, No_Telpon, Jenis_Kelamin) values ('PGW02','Anggi Hasian','Surakarta','085362633993','L')" +
                    "insert into Pegawai (ID_Pegawai, Nama_Pegawai, Alamat_Pegawai, No_Telpon, Jenis_Kelamin) values ('PGW03','Pragitya Faazha','Bandung','081623411738','P')" +
                    "insert into Pegawai (ID_Pegawai, Nama_Pegawai, Alamat_Pegawai, No_Telpon, Jenis_Kelamin) values ('PGW04','Aldy Ahmad','Pekalongan','082637199326','L')" +
                    "insert into Pegawai (ID_Pegawai, Nama_Pegawai, Alamat_Pegawai, No_Telpon, Jenis_Kelamin) values ('PGW05','Devina Shifra','Gunungkidul','081723916437','P')" +
                    "insert into Obat (ID_Obat, Nama_Obat, Jenis_Obat, Harga_Obat, Stok_Obat, ID_Pegawai) values ('OBT001','Intunal','Tablet','Rp 4.000,00','100','PGW01')" +
                    "insert into Obat (ID_Obat, Nama_Obat, Jenis_Obat, Harga_Obat, Stok_Obat, ID_Pegawai) values ('OBT002','OBH Combi Batuk Berdahak','Sirup','Rp 13.500,00','75','PGW02')" +
                    "insert into Obat (ID_Obat, Nama_Obat, Jenis_Obat, Harga_Obat, Stok_Obat, ID_Pegawai) values ('OBT003','Sanmol 1 Strip 4 tablet','Tablet','Rp 1.568,00','55','PGW03')" +
                    "insert into Obat (ID_Obat, Nama_Obat, Jenis_Obat, Harga_Obat, Stok_Obat, ID_Pegawai) values ('OBT004','Bye Bye Fever Bayi','Tempel','Rp 7.500,00','20','PGW04')" +
                    "insert into Obat (ID_Obat, Nama_Obat, Jenis_Obat, Harga_Obat, Stok_Obat, ID_Pegawai) values ('OBT005','Degirol','Tablet','Rp 13.500,00','80','PGW05')" +
                    "insert into Supplier (ID_Supplier, Nama_Supplier, Alamat_Supplier, No_Telpon) values ('S01','Adila Tsabita','Purwokerto','081382943871')" +
                    "insert into Supplier (ID_Supplier, Nama_Supplier, Alamat_Supplier, No_Telpon) values ('S02','Safira Itsna','Klaten','085273844893')" +
                    "insert into Supplier (ID_Supplier, Nama_Supplier, Alamat_Supplier, No_Telpon) values ('S03','Elfira Rahma','Magetan','087253834943')" +
                    "insert into Supplier (ID_Supplier, Nama_Supplier, Alamat_Supplier, No_Telpon) values ('S04','Jauza Aqilah','Lombok','082618949479')" +
                    "insert into Supplier (ID_Supplier, Nama_Supplier, Alamat_Supplier, No_Telpon) values ('S05','Tania Nahwa','Temanggung','081739058349')" +
                    );
            }
        }
        static void Main(string[] args)
        {
            new Program().CreateTable();
        }
    }
}