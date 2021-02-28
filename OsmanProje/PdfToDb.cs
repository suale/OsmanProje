using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace OsmanProje
{
    public class PdfToDb
    {


        public static void SinavKaydet(string satir)
        {

          


            string[] words = satir.Split(' ');
            //  Console.WriteLine(words[(words.Length-1)]) ;

            int OgrenciID = Int32.Parse(words[1]);

            int DerGenel = Int32.Parse(words[(words.Length - 1)]);
            int DerIl = Int32.Parse(words[(words.Length - 2)]);
            int DerIlce = Int32.Parse(words[(words.Length - 3)]);
            int DerSinif = Int32.Parse(words[(words.Length - 4)]);
            int DerOkul = Int32.Parse(words[(words.Length - 5)]);
            float Puan = float.Parse(words[(words.Length - 6)]);
            float ToplamN = float.Parse(words[(words.Length - 7)]);
            int ToplamY = Int32.Parse(words[(words.Length - 8)]);
            int ToplamD = Int32.Parse(words[(words.Length - 9)]);
            float FenN = float.Parse(words[(words.Length - 10)]);
            int FenY = Int32.Parse(words[(words.Length - 11)]);
            int FenD = Int32.Parse(words[(words.Length - 12)]);
            float MatN = float.Parse(words[(words.Length - 13)]);
            int MatY = Int32.Parse(words[(words.Length - 14)]);
            int MatD = Int32.Parse(words[(words.Length - 15)]);
            float IngN = float.Parse(words[(words.Length - 16)]);
            int IngY = Int32.Parse(words[(words.Length - 17)]);
            int IngD = Int32.Parse(words[(words.Length - 18)]);
            float DinN = float.Parse(words[(words.Length - 19)]);
            int DinY = Int32.Parse(words[(words.Length - 20)]);
            int DinD = Int32.Parse(words[(words.Length - 21)]);
            float TarihN = float.Parse(words[(words.Length - 22)]);
            int TarihY = Int32.Parse(words[(words.Length - 23)]);
            int TarihD = Int32.Parse(words[(words.Length - 24)]);
            float TurkceN = float.Parse(words[(words.Length - 25)]);
            int TurkceY = Int32.Parse(words[(words.Length - 26)]);
            int TurkceD = Int32.Parse(words[(words.Length - 27)]);



            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {

                cnn.Execute("insert into Sinavlar (SinavID,OgrenciID,DerGenel,DerIl,DerIlce,DerOkul,DerSinif,Puan,ToplamD,ToplamY,ToplamN,FenD,FenY,FenN,MatD,MatY,MatN,IngD,IngY,IngN,DinD,DinY,DinN,TarihD,TarihY,TarihN,TurkceD,TurkceY,TurkceN) values (1,@OgrenciID,@DerGenel,@DerIl,@DerIlce,@DerOkul,@DerSinif,@Puan,@ToplamD,@ToplamY,@ToplamN,@FenD,@FenY,@FenN,@MatD,@MatY,@MatN,@IngD,@IngY,@IngN,@DinD,@DinY,@DinN,@TarihD,@TarihY,@TarihN,@TurkceD,@TurkceY,@TurkceN)");
            }
        }



















        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

    }
}
