namespace CodeBase.Services.SaveService.SaveDateProvider
{
    public interface ISaveDateProvider
    {
        public SaveData SaveData { get;}
        public void SaveProgress();
    }
}