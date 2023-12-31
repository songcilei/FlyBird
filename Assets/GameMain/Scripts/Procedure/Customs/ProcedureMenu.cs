using System.Collections;
using System.Collections.Generic;
using FlyBrid;
using GameFramework.Event;
using GameFramework.Fsm;
using GameFramework.Procedure;
using UnityEngine;
using UnityGameFramework.Runtime;
using GameEntry = FlyBrid.GameEntry;

public class ProcedureMenu : ProcedureBase
{
    public bool IsStartGame { get; set; }

    /// <summary>
    /// 菜单界面脚本
    /// </summary>
    private MenuForm m_MenuForm = null;
    
    protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
    {
        base.OnEnter(procedureOwner);
        IsStartGame = false;
        
        //订阅UI打开成功事件
        GameEntry.Event.Subscribe(OpenUIFormSuccessEventArgs.EventId,OnOpenUIFormSuccess);
        
        //打开UI界面
        GameEntry.UI.OpenUIForm(UIFormId.MenuForm, this);
    }


    protected override void OnUpdate(IFsm<IProcedureManager> procedureOwner, float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

        if (IsStartGame)
        {
            //切换到主场景
            procedureOwner.SetData<VarInt>(Constant.ProcedureData.NextSceneId,GameEntry.Config.GetInt("Scene.Main"));
            ChangeState<ProcedureChangeScene>(procedureOwner);
        }
    }

    protected override void OnLeave(IFsm<IProcedureManager> procedureOwner, bool isShutdown)
    {
        base.OnLeave(procedureOwner, isShutdown);
        if (m_MenuForm != null)
        {
            m_MenuForm.Close(isShutdown);
            m_MenuForm = null;
        }
        //取消订阅UI打开成功事件
        GameEntry.Event.Unsubscribe(OpenUIFormSuccessEventArgs.EventId,OnOpenUIFormSuccess);
    }


    private void OnOpenUIFormSuccess(object sender,GameEventArgs e)
    {
        OpenUIFormSuccessEventArgs ne = (OpenUIFormSuccessEventArgs)e;
        if (ne.UserData != this)
        {
            return;
        }

        m_MenuForm = (MenuForm)ne.UIForm.Logic;
    }
    

}
