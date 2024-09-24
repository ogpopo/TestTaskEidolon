using System.Collections.Generic;
using CodeBase.Services.SaveService.SaveDateProvider;
using CodeBase.Services.ServerRequesterService;
using CodeBase.Services.TimerService;
using Cysharp.Threading.Tasks;
using Zenject;

namespace CodeBase.Services.EventService
{
    public class EventService : IEventService, IInitializable
    {
        private const int CooldownBeforeSend = 3;
        
        private readonly IServerEventRequesterService _requesterService;
        private readonly ITimerService _timer;
        private readonly SaveDateProvider _saveDateProvider;

        public EventService(IServerEventRequesterService requesterService, 
            ITimerService timer, 
            SaveDateProvider saveDateProvider)
        {
            _requesterService = requesterService;
            _timer = timer;
            _saveDateProvider = saveDateProvider;
        }

        private Queue<Event> EventsQueue => _saveDateProvider.SaveData.EventsQueue;
        
        public void TrackEvent(string type, string data)
        {
            var @event = new Event()
            {
                Type = type,
                Data = data
            };
            
            EventsQueue.Enqueue(@event);
        }

        public async void Initialize()
        {
            await RequestedToServer();
            _timer.AddTimer(CooldownBeforeSend, RequestAtTime);
        }

        private async void RequestAtTime()
        {
            await RequestedToServer();
            _timer.AddTimer(CooldownBeforeSend, RequestAtTime);
        }
        
        private async UniTask RequestedToServer()
        {
            for (var i = 0; i < EventsQueue.Count; i++)
            {
                Event post = EventsQueue.Peek();
                bool result = await _requesterService.Request(post);

                if (result == true)
                {
                    EventsQueue.Dequeue();
                }
            }
        }
    }
}