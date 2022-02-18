using System.Collections.Generic;
using System.IO;

namespace Vakor.DataBase.Lib.FileWriters
{
    public class FileWriter : IFileWriter
    {
        private readonly string _directoryPath;

        public FileWriter(string directoryPath)
        {
            _directoryPath = directoryPath;
        }

        public void WriteToFile(IEnumerable<string> fileData, string fileName)
        {
            if (!Directory.Exists(_directoryPath))
            {
                Directory.CreateDirectory(_directoryPath);
            }
            
            File.WriteAllLines(_directoryPath + $"/{fileName}",fileData);
        }
    }
}