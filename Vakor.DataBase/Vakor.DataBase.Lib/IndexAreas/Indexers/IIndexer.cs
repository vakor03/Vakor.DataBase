namespace Vakor.DataBase.Lib.IndexAreas.Indexers
{
    public interface IIndexer
    {
        public int StartKeyValue { get; set; }
        public int EndKeyValue { get; set; }
        public int ObjectBlockId { get; set; }

        public string GenerateString();
    }
}