using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace GameMain
{
    public abstract class Entity : EntityLogic
    {

        //[SerializeField]
        //private EntityData m_EntityData = null;
#if UNITY_EDITOR
        [Editor.ExposeProperty]
#endif
        public int Id
        {
            get
            {
                return Entity.Id;
            }
        }
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
        }   
        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
        }
        protected override void OnHide(bool isShutdown, object userData)
        {
            base.OnHide(isShutdown, userData);
        }
        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
        }
        protected override void OnRecycle()
        {
            base.OnRecycle();
        }
    }

}
