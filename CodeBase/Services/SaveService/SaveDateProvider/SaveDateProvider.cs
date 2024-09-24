using Zenject;

namespace CodeBase.Services.SaveService.SaveDateProvider
{
    public class SaveDateProvider : ISaveDateProvider, IInitializable
    {
        private readonly ISaveService _saveService;

        public SaveDateProvider(ISaveService saveService)
        {
            _saveService = saveService;
        }

        public SaveData SaveData { get; private set; }

        public void Initialize()
        {
            SaveData = _saveService.Load();
        }

        // этот метод не вызываеться, его нужно вызывать из инфраструктурного кода, по этому не стал писать это в Dispose
        public void SaveProgress()
        {
            _saveService.Save(SaveData);
        }
    }
}