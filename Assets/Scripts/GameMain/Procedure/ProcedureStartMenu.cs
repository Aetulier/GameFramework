using GameFramework.Procedure;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;
using UnityGameFramework.Runtime;
using GameFramework.Event;

namespace GameName
{
    public class ProcedureStartMenu : ProcedureBase
    {

        private int StarMenuId;
        private bool EnterGame = true;
        protected override void OnInit(ProcedureOwner procedureOwner, object userData)
        {
            base.OnInit(procedureOwner, userData);
           
        }

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);

            EnterGame = false;
            GameEntry.Event.Subscribe(EventName.GamePlayer, GamePlayer);
            StarMenuId = GameEntry.UI.OpenUIForm_Ex(AssetUtility.GetUIAsset("Start"), "Menu");
            
        }
        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
            if (EnterGame)
            {
                procedureOwner.SetData<VarInt32>("NextSceneId", GameEntry.Config.GetInt("Scene.Battle"));
                procedureOwner.SetData<VarString>("NextProcedureName", "GameName.ProcedureBattle");
                ChangeState<ProcedureChangeScene>(procedureOwner);
            }
               
        }
        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);
            EnterGame = false;

            GameEntry.Event.Unsubscribe(EventName.GamePlayer, GamePlayer);

        }
        protected override void OnDestroy(ProcedureOwner procedureOwner)
        {
            base.OnDestroy(procedureOwner);

        }


        private void GamePlayer(object sender, GameEventArgs e)
        {
            GameEntry.UI.CloseUIForm(StarMenuId);
            EnterGame = true;
        }

       
    }
}

