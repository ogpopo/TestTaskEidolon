using System.IO;
using UnityEngine;

namespace CodeBase.Services.SaveService
{
    public class JsonSaveService : ISaveService
    {
        private readonly string _filePath;

        public JsonSaveService()
        {
            _filePath = Application.persistentDataPath + "/Save.json";
        }

        public void Save(SaveData data)
        {
            var json = JsonUtility.ToJson(data);
            using (var writer = new StreamWriter(_filePath))
            {
                writer.WriteLine(json);
            }
        }

        public SaveData Load()
        {
            var json = "";
            using (var reader = new StreamReader(_filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    json += line;
                }
            }

            if (string.IsNullOrEmpty(json))
            {
                return new SaveData();
            }

            return JsonUtility.FromJson<SaveData>(json);
        }
    }
}