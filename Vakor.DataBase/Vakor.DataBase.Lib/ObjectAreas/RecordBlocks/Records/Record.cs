namespace Vakor.DataBase.Lib.ObjectAreas.RecordBlocks.Records
{
    public class Record : IRecord
    {
        public int Key { get; }
        public string Data { get; set; }
        
        public Record(int key, string data)
        {
            Key = key;
            Data = data;
        }

        public Record(string recordString)
        {
            Key = int.Parse(recordString.Substring(0,recordString.IndexOf(';')));
            Data = recordString.Substring(recordString.IndexOf(';') + 1);
        }
        
        public string GenerateString()
        {
            string result = $"{Key};{Data}";
            return result;
        }
    }
}