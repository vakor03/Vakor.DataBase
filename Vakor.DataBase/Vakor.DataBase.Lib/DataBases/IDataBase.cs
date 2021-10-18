using System.Collections.Generic;
using Vakor.DataBase.Lib.IndexAreas;
using Vakor.DataBase.Lib.ObjectAreas;

namespace Vakor.DataBase.Lib.DataBases
{
    public interface IDataBase
    {
        public string PathToDBDirectory { get; set; }

        IIndexArea IndexArea { get; set; }
        IObjectArea ObjectArea { get; set; }
        void Add(string recordData);
        void Add(int key, string recordData);
        void Remove(int key);
        string Search(int key);
        void CreateDataBase(int capacity);
        void SaveChanges();
        void OpenConnection();
        
    }
}