using System;
using System.Collections.Generic;
using ModestTree;
using UnityEngine;
using Zenject;

namespace CodeBase.Services.TimerService
{
    public class TimerService : ITimerService, ITickable
    {
        private List<(Action, float)> _timersActions = new();

        public void Tick()
        {
            for (var i = 0; i < _timersActions.Count; i++)
            {
                var timersAction = _timersActions[i];
                timersAction.Item2 -= Time.deltaTime;
                _timersActions[i] = timersAction;

                if (_timersActions[i].Item2 <= 0)
                {
                    _timersActions[i].Item1?.Invoke();
                    _timersActions.RemoveAt(i);
                }
                else
                {
                    return;
                }
            }
        }

        public void AddTimer(float time, Action callback)
        {
            var timerAction = (callback, time);

            if (_timersActions.IsEmpty())
            {
                _timersActions.Add(timerAction);

                return;
            }

            _timersActions.Add(timerAction);
            _timersActions.Sort();
        }
    }
}