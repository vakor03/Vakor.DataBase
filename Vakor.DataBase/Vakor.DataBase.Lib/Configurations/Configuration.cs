using System;

namespace Vakor.DataBase.Lib.Configurations
{
    public class Configuration : IConfiguration

    {
        public int LastIndex { get; set; }
        public int BlocksCount { get; set; } = 10;
        public int BlockCapacity { get; set; }

        public Configuration()
        {
        }

        public Configuration(int capacity)
        {
            CreateNew(capacity);
        }

        public Configuration(string[] configurationData)
        {
            CreateFromData(configurationData);
        }

        private void CreateNew(int capacity)
        {
            BlockCapacity = (int) Math.Ceiling((double) capacity / BlocksCount);
            LastIndex = 0;
        }

        private void CreateFromData(string[] configurationData)
        {
            LastIndex = int.Parse(configurationData[0]);
            BlockCapacity = int.Parse(configurationData[1]);
            BlocksCount = int.Parse(configurationData[2]);
        }

        public double FillIndex => (double) LastIndex / (BlockCapacity * BlocksCount);

        public string[] GenerateOutputData()
        {
            return new[] {$"{LastIndex}\n{BlockCapacity}\n{BlocksCount}"};
        }

        public void ChangeMaxCapacity(double extendCapacity)
        {
            BlockCapacity = (int)(BlockCapacity * extendCapacity);
        }
    }
}