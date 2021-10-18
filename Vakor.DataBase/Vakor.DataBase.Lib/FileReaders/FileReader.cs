using System.IO;

namespace Vakor.DataBase.Lib.FileReaders
{
    public class FileReader : IFileReader
    {
        private readonly string _directoryPath;

        public FileReader(string directoryPath)
        {
            _directoryPath = directoryPath;
        }

        public string[] ReadFile(string fileName)
        {
            string filePath = _directoryPath + "/" + fileName;
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException();
            }

            return File.ReadAllLines(filePath);
        }
    }
}