using System;
using System.Linq;
using Vakor.DataBase.Lib.Configurations;
using Vakor.DataBase.Lib.ObjectAreas.RecordBlocks;
using Vakor.DataBase.Lib.ObjectAreas.RecordBlocks.Records;

namespace Vakor.DataBase.Lib.ObjectAreas
{
    public class ObjectArea : IObjectArea
    {
        public IRecordBlock[] RecordBlocks { get; set; }

        private IConfiguration _configuration;

        public ObjectArea(IConfiguration configuration, string[] objectAreaData)
        {
            _configuration = configuration;
            CreateFromData(objectAreaData);
        }

        public ObjectArea(IConfiguration configuration)
        {
            _configuration = configuration;
            CreateDefault();
        }


        public string[] GenerateOutputData()
        {
            string[] outputData = new string[_configuration.BlocksCount * _configuration.BlockCapacity];
            for (int i = 0; i < _configuration.BlocksCount; i++)
            {
                for (int j = 0; j < _configuration.BlockCapacity; j++)
                {
                    int a = RecordBlocks[i].Records.Count;
                    if (RecordBlocks[i].Records.Count > j)
                    {
                        outputData[i * _configuration.BlockCapacity + j] = RecordBlocks[i][j].GenerateString();
                    }
                    else
                    {
                        outputData[i * _configuration.BlockCapacity + j] = String.Empty;
                    }
                }
            }

            return outputData;
        }

        public void AddRecord(string recordData)
        {
            RecordBlocks[_configuration.LastIndex / _configuration.BlockCapacity]
                .Add(new Record(_configuration.LastIndex++, recordData));
        }

        public void AddRecord(IRecord recordData)
        {
            RecordBlocks[recordData.Key/_configuration.BlockCapacity].Add(recordData);
        }

        public void RemoveRecord(int key)
        {
            int blockId = key / _configuration.BlockCapacity;
            RecordBlocks[blockId].Delete(key);
        }

        public IRecord SearchRecord(int key)
        {
            return RecordBlocks[key / _configuration.BlockCapacity].SearchRecord(key);
        }

        public void Resize()
        {
            IRecordBlock[] newRecordBlocks = new IRecordBlock[_configuration.BlocksCount];
            for (int i = 0; i < newRecordBlocks.Length; i++)
            {
                newRecordBlocks[i] = new RecordBlock();
            }

            foreach (var recordBlock in RecordBlocks)
            {
                foreach (var record in recordBlock.Records)
                {
                    newRecordBlocks[record.Key / _configuration.BlockCapacity]
                        .Add(record);
                }
            }

            RecordBlocks = newRecordBlocks;
        }

        private void CreateFromData(string[] objectAreaData)
        {
            RecordBlocks = new IRecordBlock[_configuration.BlocksCount];

            for (int i = 0; i < _configuration.BlocksCount; i++)
            {
                RecordBlocks[i] = new RecordBlock();
                for (int j = 0; j < _configuration.BlockCapacity; j++)
                {
                    string recordString = objectAreaData[i * _configuration.BlockCapacity + j];
                    if (!string.IsNullOrWhiteSpace(recordString))
                    {
                        RecordBlocks[i].Add(new Record(recordString));
                    }
                }
            }
        }

        private void CreateDefault()
        {
            RecordBlocks = new IRecordBlock[_configuration.BlocksCount];
            for (int i = 0; i < _configuration.BlocksCount; i++)
            {
                RecordBlocks[i] = new RecordBlock();
            }
        }
    }
}