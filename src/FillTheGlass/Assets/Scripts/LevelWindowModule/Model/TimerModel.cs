using System;
using Savidiy.Utils;
using UniRx;

namespace LevelWindowModule
{
    public class TimerModel : IDisposable
    {
        private readonly TickInvoker _tickInvoker;
        private readonly ReactiveProperty<float> _timeRemain = new();

        public float LevelDuration;
        public bool IsTimeExited => TimeRemain.Value > 0;
        public ReactiveProperty<float> TimeRemain => _timeRemain;

        public TimerModel(TickInvoker tickInvoker, float duration)
        {
            _tickInvoker = tickInvoker;
            LevelDuration = duration;
            TimeRemain.Value = duration;

            tickInvoker.Updated += OnUpdated;
        }

        private void OnUpdated()
        {
            float newTime = TimeRemain.Value - _tickInvoker.DeltaTime;

            TimeRemain.Value = newTime;
        }

        public void Dispose()
        {
            _timeRemain?.Dispose();
            _tickInvoker.Updated -= OnUpdated;
        }
    }
}