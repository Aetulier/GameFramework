using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;
using UnityEngine.UI;
using GameFramework.Event;

namespace GameName
{
    public class UITest : UIFormLogic
    {
        public Text text;
        public Button button1;
        public Button button2;

        int index = 1;
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            Log.Debug("打开Test");

            GameEntry.Event.Subscribe(TestArgs.EventId, OnTextChanged);



            button1.onClick.AddListener(() =>
            {

                 //"Assets/GameMain/Prefabs/Capsule.prefab"
                index++;
            });

            button2.onClick.AddListener(() =>
            {
                GameEntry.Event.Fire(this, TestArgs.Create("Ellan"));

            });

        }




        protected override void OnClose(bool isShutdown, object userData)
        {
            base.OnClose(isShutdown, userData);


        }

        private void OnTextChanged(object sender, GameEventArgs e)
        {
            TestArgs ne = (TestArgs)e;
            text.text = ne.NewText;
        }

    }
}
