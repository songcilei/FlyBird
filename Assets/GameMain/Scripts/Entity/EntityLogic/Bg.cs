using System.Collections;
using System.Collections.Generic;
using FlyBrid;
using UnityEngine;

/// <summary>
/// 背景实体脚本
/// </summary>
public class Bg : Entity
{

    /// <summary>
    /// 背景实体数据
    /// </summary>
    private BgData m_BgData;

    private bool m_IsSpawn = false;
    
    
    
    protected override void OnShow(object userData)
    {
        base.OnShow(userData);
        m_BgData = (BgData)userData;//这里是从外面的ProcedureMain 创建的时候传进来的值？
        //修改开始位置  这里CachedTransform 是缓存的Transform
        CachedTransform.SetLocalPositionX(m_BgData.StartPosition);
    }
    protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(elapseSeconds, realElapseSeconds);
        //控制背景实体移动
        CachedTransform.Translate(Vector3.left * m_BgData.MoveSpeed * elapseSeconds,Space.World);
        if (CachedTransform.position.x <= m_BgData.SpawnTarget && m_IsSpawn == false)
        {
            //显示背景实体
            GameEntry.Entity.ShowBg(new BgData(GameEntry.Entity.GenerateSerialId(), m_BgData.TypeId, m_BgData.MoveSpeed, 17.92f));

            m_IsSpawn = true;
        }

        if (CachedTransform.position.x <= m_BgData.HideTarget)
        {
            //隐藏实体
            GameEntry.Entity.HideEntity(this);
        }

    }
    protected override void OnHide(object userData)
    {
        base.OnHide(userData);
        m_IsSpawn = false;
        
    }


}
