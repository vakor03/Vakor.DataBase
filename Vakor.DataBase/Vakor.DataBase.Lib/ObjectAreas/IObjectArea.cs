using Vakor.DataBase.Lib.ObjectAreas.RecordBlocks.Records;

namespace Vakor.DataBase.Lib.ObjectAreas
{
    public interface IObjectArea
    {
        public const string AreaName = ".objectArea";
        string[] GenerateOutputData();
        void AddRecord(string recordData);
        void RemoveRecord(int key);
        IRecord SearchRecord(int key);
        void Resize();
        void AddRecord(IRecord recordData);
    }
}