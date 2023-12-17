using GameFramework.Event;

namespace FlyBrid
{
    public class AddScoreEventArgs : GameEventArgs
    {

        public static readonly int EventId = typeof(AddScoreEventArgs).GetHashCode();

        //加分数量
        public int AddCount { get; private set; }

        public override void Clear()
        {
            AddCount = 0;
        }

        //充填事件
        public AddScoreEventArgs Fill(int addCount)
        {
            AddCount = addCount;
            return this;
        }

        public override int Id {
            get
            {
                return EventId;
            }
        } 
    }
}