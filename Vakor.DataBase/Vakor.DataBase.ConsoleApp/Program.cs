using System;
using System.Linq;
using Vakor.DataBase.Lib.DataBases;

namespace Vakor.DataBase.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataBase dataBase = new Lib.DataBases.DataBase(@"C:\Users\Vakor\Pictures\DataBase");
            //dataBase.OpenConnection();
            dataBase.CreateDataBase(100);
            // for (int i = 0; i < 100; i++)
            // {
            //     int key = 1;
            //     dataBase.Add(RandomString(14));
            //     dataBase.Add(key, RandomString(14));
            // }
            // dataBase.Remove(1);
            // dataBase.Remove(2);
            // dataBase.Remove(3);
            dataBase.Add(25, RandomString(25));
            //Console.WriteLine(dataBase.Search(4));
            dataBase.SaveChanges();
        }
        
        public static string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789; ,.";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}