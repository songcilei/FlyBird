using GameFramework.Event;

namespace FlyBrid
{
    public class RestarEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(RestarEventArgs).GetHashCode();
        
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