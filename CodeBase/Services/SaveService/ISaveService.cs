﻿namespace CodeBase.Services.SaveService
{
    public interface ISaveService
    {
        public void Save(SaveData data);
        public SaveData Load();
    }
}