namespace Assets.Scripts.PlayerScripts.PlayerComponents
{
    public class WheatComponent : PlayerComponent, IEditableComponent
    {
        public void Add(int value)
        {
            if (CurrentValue + value <= MaxValue)
            {
                CurrentValue += value;
                return;
            }
            CurrentValue = MaxValue;
        }

        public int Reset()
        {
            int value = CurrentValue;
            CurrentValue = 0;
            return value;
        }
    }
}