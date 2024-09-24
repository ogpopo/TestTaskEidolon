using System;

namespace CodeBase.Services.EventService
{
    [Serializable]
    public struct Event
    {
        public string Type;
        public string Data;
    }
}