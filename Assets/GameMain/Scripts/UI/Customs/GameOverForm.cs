using FlyBrid;
using GameFramework;
using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime;
using GameEntry = FlyBrid.GameEntry;

namespace GameMain.Scripts.UI.Customs
{
    /// <summary>
    /// 游戏结束界面
    /// </summary>
    public class GameOverForm : UGuiForm
    {
        public Text Score;

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);
            (transform as RectTransform).anchoredPosition = Vector3.zero;
            //获取分数
            int score = GameEntry.DataNode.GetNode("Score").GetData<VarInt>();
            Score.text = "你的总分:" + score;
        }

        protected override void OnClose(object userData)
        {
            base.OnClose(userData);
            Score.text = string.Empty;
        }

        public void OnRestartButtonClick()
        {
            Close(true);
            
            //派发重新开始游戏事件
            GameEntry.Event.Fire(this,ReferencePool.Acquire<RestarEventArgs>());
            
            //显示小鸟
            GameEntry.Entity.ShowBird(new BirdData(GameEntry.Entity.GenerateSerialId(),3,5f));
            
            
        }

        public void OnReturnButtonClick()
        {
            Close(true);
            //派发返回菜单场景事件
            GameEntry.Event.Fire(this,ReferencePool.Acquire<ReturnMenuEventArgs>());
            
        }
    }
}