using System.Collections.Generic;
using Vakor.DataBase.Lib.IndexAreas;
using Vakor.DataBase.Lib.ObjectAreas;
using Vakor.DataBase.Lib.ObjectAreas.RecordBlocks.Records;

namespace Vakor.DataBase.Lib.DataBases
{
    public interface IDataBase
    {
        public string PathToDBDirectory { get; set; }

        IIndexArea IndexArea { get; set; }
        IObjectArea ObjectArea { get; set; }
        IRecord Add(string recordData);
        IRecord Add(int key, string recordData);
        void Remove(int key);
        IRecord Search(int key, out int searchIterator);
        void CreateDataBase(int capacity);
        void SaveChanges();
        void OpenConnection();
        
    }
}