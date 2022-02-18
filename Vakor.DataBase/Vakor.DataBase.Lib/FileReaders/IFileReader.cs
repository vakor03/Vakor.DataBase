using System.IO;

namespace Vakor.DataBase.Lib.FileReaders
{
    public interface IFileReader
    {
        public string[] ReadFile(string fileName);
    }
}