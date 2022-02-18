using Vakor.DataBase.Lib.ObjectAreas.RecordBlocks.Records;

namespace Vakor.DataBase.Lib.ObjectAreas
{
    public interface IObjectArea
    {
        public const string AreaName = ".objectArea";
        string[] GenerateOutputData();
        IRecord AddRecord(string recordData);
        void RemoveRecord(int key);
        IRecord SearchRecord(int key, out int iterationIndex);
        void Resize();
        IRecord AddRecord(IRecord recordData);
    }
}