using System.Linq;

namespace Vakor.DataBase.Lib.IndexAreas.Indexers
{
    public class Indexer : IIndexer
    {
        public int StartKeyValue { get; set; }
        public int EndKeyValue { get; set; }
        public int ObjectBlockId { get; set; }

        public Indexer()
        {
        }
        
        public Indexer(string indexerString)
        {
            var values = indexerString.Split(';').Take(3).Select(int.Parse).ToArray();
            (StartKeyValue, EndKeyValue, ObjectBlockId) = (values[0], values[1], values[2]);
        }

        public string GenerateString()
        {
            string result = $"{StartKeyValue};{EndKeyValue};{ObjectBlockId}";
            return result;
        }
    }
}