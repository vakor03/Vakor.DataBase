namespace Vakor.DataBase.Lib.Configurations
{
    public interface IConfiguration
    {
        public const string FileName = ".config";
        int BlockCapacity { get; set; }
        int BlocksCount { get; set; }
        int LastIndex { get; set; }
        double FillIndex { get; }

        string[] GenerateOutputData();
        void ChangeMaxCapacity(double extendCapacity);
    }
}