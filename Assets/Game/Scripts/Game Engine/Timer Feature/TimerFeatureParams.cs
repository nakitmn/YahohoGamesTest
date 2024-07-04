namespace Game.Scripts.Game_Engine.Timer_Feature
{
    public readonly struct TimerFeatureParams
    {
        public readonly float Duration;
        public readonly bool IsRepeatable;

        public TimerFeatureParams(float duration, bool isRepeatable)
        {
            Duration = duration;
            IsRepeatable = isRepeatable;
        }
    }
}