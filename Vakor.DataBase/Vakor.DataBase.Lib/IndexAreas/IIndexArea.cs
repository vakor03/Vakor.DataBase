using Vakor.DataBase.Lib.IndexAreas.Indexers;

namespace Vakor.DataBase.Lib.IndexAreas
{
    public interface IIndexArea
    {
        public const string AreaName = ".indexArea";
        IIndexer[] Indexers { get; set; }
        string[] GenerateOutputData();
        void Resize();
    }
}