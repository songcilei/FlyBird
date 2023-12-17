using GameFramework.Event;

namespace FlyBrid
{
    public class BirdDeadEventArgs : GameEventArgs
    {

        public static readonly int EventId = typeof(BirdDeadEventArgs).GetHashCode();
        
        
        public override void Clear()
        {
            throw new System.NotImplementedException();
        }

        public override int Id {
            get
            {
                return EventId;
            }
        }
    }
}