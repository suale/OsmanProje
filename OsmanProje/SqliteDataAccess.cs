using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace OsmanProje
{
   public class SqliteDataAccess
    {
        public static IEnumerable<dynamic> SekizOgrenciYukle()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var Ad = "";
                var Numara = 0;

                var query = "Select * from Sekizliste";
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("OgrenciAD", Ad);
                dynamicParameters.Add("OgrenciID", Numara);
                IEnumerable<dynamic> results = cnn.Query(query, dynamicParameters);

                return results;


            }
        }


        public static IEnumerable<dynamic> YediOgrenciYukle()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var Ad = "";
                var Numara = 0;

                var query = "Select * from Yediliste";
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("OgrenciAD", Ad);
                dynamicParameters.Add("OgrenciID", Numara);
                IEnumerable<dynamic> results = cnn.Query(query, dynamicParameters);

                return results;


            }
        }




        public static void SekizOgrenciKaydet(OgrenciModel ogrenci)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into SekizListe (OgrenciAD) values (@Ad)", ogrenci);
            }
        }

        public static void YediOgrenciKaydet(OgrenciModel ogrenci)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into YediListe (OgrenciAD) values (@Ad)", ogrenci);
            }
        }
        public static void OgrenciSil(OgrenciModel ogrenci)
        {
            if (ogrenci.Id < 8000)
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    cnn.Execute("delete from YediListe where OgrenciID= (@Id)", ogrenci);
                }
            else if(ogrenci.Id>7000)
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    cnn.Execute("delete from SekizListe where OgrenciID= (@Id)", ogrenci);
                }
        }



        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

    }
}
