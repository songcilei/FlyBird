using GameFramework.Event;

namespace FlyBrid
{
    public class ReturnMenuEventArgs : GameEventArgs
    {

        public static readonly int EventId = typeof(ReturnMenuEventArgs).GetHashCode();
        public override void Clear()
        {
            throw new System.NotImplementedException();
        }

        public override int Id
        {
            get { return EventId; }
        }
    }
}