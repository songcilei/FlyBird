using UnityEngine;

namespace FlyBrid
{
    public class BulletData : EntityData
    {

        //发射位置
        public Vector2 ShootPosition { get; private set; }

        //飞行速度
        public float FlySpeed { get; private set; }

        public BulletData(int entityId, int typeId, Vector2 shootPosition ,float flySpeed) : base(entityId, typeId)
        {
            ShootPosition = shootPosition;
            FlySpeed = flySpeed;
        }
    }
}