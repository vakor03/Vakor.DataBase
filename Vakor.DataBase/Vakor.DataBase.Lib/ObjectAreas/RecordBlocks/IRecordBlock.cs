using System.Collections.Generic;
using Vakor.DataBase.Lib.ObjectAreas.RecordBlocks.Records;

namespace Vakor.DataBase.Lib.ObjectAreas.RecordBlocks
{
    public interface IRecordBlock
    {
        public List<IRecord> Records { get; }

        public void Add(IRecord record);
        public void Delete(int recordKey);
        public void Delete(IRecord record);
        IRecord this[int i] { get; }
        IRecord SearchRecord(int key, out int iterationIndex);
    }
}