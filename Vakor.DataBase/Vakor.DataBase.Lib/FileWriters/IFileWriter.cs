using System.Collections.Generic;

namespace Vakor.DataBase.Lib.FileWriters
{
    public interface IFileWriter
    {
        public void WriteToFile(IEnumerable<string> fileData, string fileName);
    }
}