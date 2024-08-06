using System;

namespace CodeBase.Services.TimerService
{
    public interface ITimerService
    {
        public void AddTimer(float time, Action callback);
    }
}