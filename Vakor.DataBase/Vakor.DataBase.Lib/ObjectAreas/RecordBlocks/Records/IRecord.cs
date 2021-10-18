namespace Vakor.DataBase.Lib.ObjectAreas.RecordBlocks.Records
{
    public interface IRecord
    {
        public int Key { get; }
        public string Data { get; set; }

        public string GenerateString();
    }
}