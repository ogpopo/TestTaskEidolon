namespace CodeBase.Services.EventService
{
    public interface IEventService
    {
        public void TrackEvent(string type, string data);
    }
}