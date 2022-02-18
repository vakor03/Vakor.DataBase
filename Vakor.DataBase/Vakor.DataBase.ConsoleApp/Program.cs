using System;
using System.Linq;
using Vakor.DataBase.Lib.DataBases;
using Vakor.DataBase.Lib.ObjectAreas.RecordBlocks.Records;

namespace Vakor.DataBase.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataBase dataBase = new Lib.DataBases.DataBase(@"C:\Users\Vakor\Pictures\DataBase");
            // dataBase.CreateDataBase(1000);
            //
            //  for (int i = 0; i < 10000; i++)
            //  {
            //      AddRecord(dataBase, RandomString(12));
            //  }
            
            dataBase.OpenConnection();
             AddRecord(dataBase, "new record", 128);
             Console.WriteLine();
             RemoveRecord(dataBase, 128);
            
             AddRecord(dataBase, "new record1", 1280);
             var a = new int[10];

             for (int i = 0; i < 15; i++)
             {
                 SearchRecord(dataBase, new Random().Next(10000));
             }
            

            dataBase.SaveChanges();
        }

        private static void RemoveRecord(IDataBase dataBase, int key)
        {
            Console.WriteLine($"\nRemoved key: {key}");
            dataBase.Remove(key);
        }

        public static void AddRecord(IDataBase dataBase, string recordData, int key = -1)
        {
            IRecord record;
            if (key == -1)
            {
                record = dataBase.Add(recordData);
            }
            else
            {
                record = dataBase.Add(key, recordData);
            }

            //Console.WriteLine($"Added record: Key: {record.Key}, Data: {record.Data}");
        }

        public static IRecord SearchRecord(IDataBase dataBase, int key)
        {
            var searchRecord = dataBase.Search(key, out int searchIterator);
            if (searchRecord == null)
            {
                Console.WriteLine($"\nSearching {key}: record not exists");
            }
            else
            {
                Console.WriteLine($"\nSearching {key}: record data: {searchRecord.Data}, iterations: {searchIterator}");
            }

            return searchRecord;
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