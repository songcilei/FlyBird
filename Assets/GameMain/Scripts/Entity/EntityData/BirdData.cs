namespace FlyBrid
{
    /// <summary>
    /// 小鸟实体数据
    /// </summary>
    public class BirdData : EntityData
    {
        /// <summary>
        /// 飞行力度
        /// </summary>
        public float FlyForce { get; private set; }

        public BirdData(int entityId, int typeId,float flyForce) : base(entityId, typeId)
        {
            FlyForce = flyForce;
        }
    }
}