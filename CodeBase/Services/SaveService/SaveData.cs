using System;
using System.Collections.Generic;
using CodeBase.Services.EventService;

namespace CodeBase.Services.SaveService
{
    [Serializable]
    public class SaveData
    {
        public Queue<Event> EventsQueue  = new();
    }
}