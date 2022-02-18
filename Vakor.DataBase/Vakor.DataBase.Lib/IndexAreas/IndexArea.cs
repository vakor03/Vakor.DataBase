using System.Linq;
using Vakor.DataBase.Lib.Configurations;
using Vakor.DataBase.Lib.IndexAreas.Indexers;

namespace Vakor.DataBase.Lib.IndexAreas
{
    public class IndexArea : IIndexArea
    {
        public IIndexer[] Indexers { get; set; }
        
        private readonly IConfiguration _configuration;

        public IndexArea(IConfiguration configuration, string[] indexAreaData)
        {
            _configuration = configuration;
            CreateFromData(indexAreaData);
        }

        public IndexArea(IConfiguration configuration)
        {
            _configuration = configuration;
            CreateFromConfig();
        }

        public string[] GenerateOutputData()
        {
            return Indexers.Select(indexer => indexer.GenerateString()).ToArray();
        }

        public void Resize()
        {
            CreateFromConfig();
        }

        private void CreateFromConfig()
        {
            Indexers = new IIndexer[_configuration.BlocksCount];
            for (int i = 0; i < Indexers.Length; i++)
            {
                Indexers[i] = new Indexer
                {
                    StartKeyValue = i * _configuration.BlockCapacity,
                    EndKeyValue = (i + 1) * _configuration.BlockCapacity,
                    ObjectBlockId = i
                };
            }
        }

        private void CreateFromData(string[] indexAreaData)
        {
            Indexers = new IIndexer[_configuration.BlocksCount];
            for (int i = 0; i < Indexers.Length; i++)
            {
                Indexers[i] = new Indexer(indexAreaData[i]);
            }
        }
    }
}