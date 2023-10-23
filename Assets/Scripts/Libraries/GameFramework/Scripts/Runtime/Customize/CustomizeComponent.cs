//------------------------------------------------------------
// Game Framework
//------------------------------------------------------------

using GameFramework;
using GameFramework.Customize;
using System;
using UnityEngine;

namespace UnityGameFramework.Runtime
{
    /// <summary>
    /// 自定义组件。
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("Game Framework/CustomizeModule")]
    public class CustomizeComponent : GameFrameworkComponent
    {
        private ICustomizeModuleManager m_customizeModuleManager = null;

        /// <summary>
        /// 游戏框架组件初始化。
        /// </summary>
        protected override void Awake()
        {
            base.Awake();

            m_customizeModuleManager = GameFrameworkEntry.GetModule<ICustomizeModuleManager>();
            if (m_customizeModuleManager == null)
            {
                Log.Fatal("customizeModule Manager is invalid.");
                return;
            }
        }

       
        public  void AddModel(ICustomizeModule customizeModule)
        {
            m_customizeModuleManager.AddCustomizeModule(customizeModule);
        }

        public ICustomizeModule GetCustomizeModule(string moduleTypeName) {

          return  m_customizeModuleManager.GetCustomizeModule(moduleTypeName);
        }

        public void RemoveModel(ICustomizeModule customizeModule) {

            m_customizeModuleManager.RemoveCustomizeModule(customizeModule);
        }
    }
}
