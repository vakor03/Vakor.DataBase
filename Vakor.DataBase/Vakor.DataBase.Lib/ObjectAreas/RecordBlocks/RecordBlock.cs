using System;
using System.Collections.Generic;
using System.Linq;
using Vakor.DataBase.Lib.ObjectAreas.RecordBlocks.Records;

namespace Vakor.DataBase.Lib.ObjectAreas.RecordBlocks
{
    public class RecordBlock : IRecordBlock
    {
        public List<IRecord> Records { get; } = new();

        public IRecord this[int i]
        {
            get {
                if (i < Records.Count)
                {
                    return Records[i];
                }

                throw new ArgumentOutOfRangeException();
            }
        }

        public IRecord SearchRecord(int key)
        {
            int first = 0;
            int last = Records.Count;
            while (first <= last)
            {
                int middle = (first + last) / 2;
                if (key < Records[middle].Key)
                {
                    last = middle - 1;
                }else if (key > Records[middle].Key)
                {
                    first = middle + 1;
                }
                else
                {
                    return Records[middle];
                }
            }
            throw new ArgumentOutOfRangeException();
        }

        public void Add(IRecord record)
        {
            Records.Add(record);
            Records.Sort((record1, record2) => record1.Key.CompareTo(record2.Key));
        }

        public void Delete(int recordKey)
        {
            Delete(SearchRecord(recordKey));
        }

        public void Delete(IRecord record)
        {
            Records.Remove(record);
        }
    }
}