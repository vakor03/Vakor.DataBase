using Vakor.DataBase.Lib.Configurations;
using Vakor.DataBase.Lib.FileReaders;
using Vakor.DataBase.Lib.FileWriters;
using Vakor.DataBase.Lib.IndexAreas;
using Vakor.DataBase.Lib.ObjectAreas;
using Vakor.DataBase.Lib.ObjectAreas.RecordBlocks.Records;

namespace Vakor.DataBase.Lib.DataBases
{
    public class DataBase : IDataBase
    {
        public string PathToDBDirectory { get; set; }
        public IIndexArea IndexArea { get; set; }
        public IObjectArea ObjectArea { get; set; }

        private readonly IFileReader _fileReader;
        private readonly IFileWriter _fileWriter;
        private IConfiguration _configuration;

        public DataBase(string pathToDbDirectory)
        {
            PathToDBDirectory = pathToDbDirectory;
            _fileWriter = new FileWriter(PathToDBDirectory);
            _fileReader = new FileReader(PathToDBDirectory);
        }

        public IRecord Add(string recordData)
        {
            while (Search(_configuration.LastIndex, out _) != null)
            {
                _configuration.LastIndex++;
            }

            if (_configuration.FillIndex >= 0.9)
            {
                Resize();
            }

            return ObjectArea.AddRecord(recordData);
        }

        public IRecord Add(int key, string recordData)
        {
            while (key >= _configuration.MaxCapacity)
            {
                Resize();
            }

            return ObjectArea.AddRecord(new Record(key, recordData));
        }

        public void Remove(int key)
        {
            ObjectArea.RemoveRecord(key);
        }

        private void Resize()
        {
            _configuration.ChangeMaxCapacity(1.5);
            IndexArea.Resize();
            ObjectArea.Resize();
        }


        public IRecord Search(int key, out int searchIterator)
        {
            var record = ObjectArea.SearchRecord(key, out searchIterator);
            return record;
        }

        public void CreateDataBase(int capacity)
        {
            _configuration = new Configuration(capacity);
            IndexArea = new IndexArea(_configuration);
            ObjectArea = new ObjectArea(_configuration);
        }

        public void SaveChanges()
        {
            _fileWriter.WriteToFile(IndexArea.GenerateOutputData(), IIndexArea.AreaName);
            _fileWriter.WriteToFile(ObjectArea.GenerateOutputData(), IObjectArea.AreaName);
            _fileWriter.WriteToFile(_configuration.GenerateOutputData(), IConfiguration.FileName);
        }

        public void OpenConnection()
        {
            _configuration = new Configuration(_fileReader.ReadFile(IConfiguration.FileName));
            IndexArea = new IndexArea(_configuration, _fileReader.ReadFile(IIndexArea.AreaName));
            ObjectArea = new ObjectArea(_configuration, _fileReader.ReadFile(IObjectArea.AreaName));
        }
    }
}