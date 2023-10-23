using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;
using UnityEngine.UI;
using GameFramework;
using GameFramework.UI;
using GameFramework.Resource;

namespace GameName
{
    public class UIStart : UGuiForm
    {
        public Button NewGameBtn;
        //public int index;
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            NewGameBtn.onClick.AddListener(() =>
            {
                GameEntry.Event.Fire(this,EventName.GamePlayer);
            });


        }
    }
}
