﻿using System;
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

                SqlCommand cm = new SqlCommand("insert into Pembeli (ID_Pembeli, Nama_Pembeli, Alamat_Pembeli, Jenis_Kelamin, No_Telpon) values ('PBL001','Tiara Sekarsini','Sumedang','P')" +
                    "insert into Pembeli (ID_Pembeli, Nama_Pembeli, Alamat_Pembeli, Jenis_Kelamin, No_Telpon) values ('PBL002','Zahwa Ladya','Makassar','P')" +
                    "insert into Pembeli (ID_Pembeli, Nama_Pembeli, Alamat_Pembeli, Jenis_Kelamin, No_Telpon) values ('PBL003','Savana Rizqi','Pati','P')" +
                    "insert into Pembeli (ID_Pembeli, Nama_Pembeli, Alamat_Pembeli, Jenis_Kelamin, No_Telpon) values ('PBL004','Zahran Rafif','Yogyakarta','L')" +
                    "insert into Pembeli (ID_Pembeli, Nama_Pembeli, Alamat_Pembeli, Jenis_Kelamin, No_Telpon) values ('PBL005','Alam Nurcahaya','Sleman','L')");
            }
        }
        static void Main(string[] args)
        {
            new Program().CreateTable();
        }
    }
}