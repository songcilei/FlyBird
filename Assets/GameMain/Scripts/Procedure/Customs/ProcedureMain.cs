using System.Collections;
using System.Collections.Generic;
using FlyBrid;
using GameFramework;
using GameFramework.Event;
using GameFramework.Fsm;
using GameFramework.Procedure;
using UnityEngine;

/// <summary>
/// 主流程
/// </summary>
public class ProcedureMain : ProcedureBase
{
    /// <summary>
    /// 管道产生时间
    /// </summary>
    private float m_PipeSpawnTime = 0f;

    
    /// <summary>
    /// 管道产生计时器
    /// </summary>
    private float m_PipeSpawnTimer = 0f;

    /// <summary>
    /// 结束界面ID
    /// </summary>
    private int m_ScoreFormId = -1;

    /// <summary>
    /// 是否返回主菜单
    /// </summary>
    private bool m_IsReturnMenu = false;
    protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
    {
        base.OnEnter(procedureOwner);

        m_ScoreFormId = GameEntry.UI.OpenUIForm(UIFormId.ScoreForm).Value;
        
        
        //加载 的entity  是  通过 typeid (这个走表)绑定到一起的
        //GenerateSerialId() 这个是用于判断是服务器(正数)还是本地的临时实体(负数)  0无效  
        GameEntry.Entity.ShowBg(new BgData(GameEntry.Entity.GenerateSerialId(),1,2f,0));

        GameEntry.Entity.ShowBird(new BirdData(GameEntry.Entity.GenerateSerialId(),3,5f));
        
        //设置初始化管道产生的时间
        m_PipeSpawnTime = Random.Range(3f, 5f);
        
        //订阅事件
        GameEntry.Event.Subscribe(ReturnMenuEventArgs.EventId,OnReturnMenu);

        
    }

    protected override void OnUpdate(IFsm<IProcedureManager> procedureOwner, float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
        m_PipeSpawnTimer += elapseSeconds;
        if (m_PipeSpawnTimer >= m_PipeSpawnTime)
        {
            m_PipeSpawnTimer = 0;
            
            //随机设置管道生产时间
            m_PipeSpawnTime = Random.Range(3f, 5f);
            
            //产生管道
            GameEntry.Entity.ShowPipe(new PipeData(GameEntry.Entity.GenerateSerialId(),2,2f));
        }

    }

    protected override void OnLeave(IFsm<IProcedureManager> procedureOwner, bool isShutdown)
    {
        base.OnLeave(procedureOwner, isShutdown);
        
        GameEntry.UI.CloseUIForm(m_ScoreFormId);
        GameEntry.Event.Unsubscribe(ReturnMenuEventArgs.EventId,OnReturnMenu);
    }

    private void OnReturnMenu(object sender,GameEventArgs e)
    {
        m_IsReturnMenu = true;
    }
}
