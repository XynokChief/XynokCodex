namespace XynokConvention.Data.Saver.APIs
{
    public interface ISaveAble
    {
     string SaveKey { get; }
     void Save();
     void Load();
    }
}