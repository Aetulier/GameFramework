using System;
using System.Collections.Generic;

namespace GameFramework.Customize
{
    internal sealed class CustomizeModuleManager : GameFrameworkModule, ICustomizeModuleManager
    {

        private GameFrameworkLinkedList<ICustomizeModule> customizeModules;


        /// <summary>
        /// 初始化自定义模块的新实例。
        /// </summary>
        public CustomizeModuleManager() {
             customizeModules = new GameFrameworkLinkedList<ICustomizeModule>();
        }

        public void AddCustomizeModule(ICustomizeModule customizeModule)
        {
            if (customizeModules.Count == 0)
                customizeModules.AddFirst(customizeModule);
            else
            customizeModules.AddLast(customizeModule);
            
        }

        public ICustomizeModule GetCustomizeModule(string moduleTypeName)
        {
            foreach (ICustomizeModule module in customizeModules)
            {
                if (module.GetType().Name == moduleTypeName)
                {
                    return module;
                }
            }
            return null;
        }


        public void RemoveCustomizeModule(ICustomizeModule customizeModule)
        {
            customizeModules.Remove(customizeModule);
        }

        /// <summary>
        /// 获取游戏框架模块优先级。
        /// </summary>
        /// <remarks>优先级较高的模块会优先轮询，并且关闭操作会后进行。</remarks>
        internal override int Priority
        {
            get
            {
                return 10;
            }
        }
        /// <summary>
        /// 自定义模块轮询。
        /// </summary>
        /// <param name="elapseSeconds">逻辑流逝时间，以秒为单位。</param>
        /// <param name="realElapseSeconds">真实流逝时间，以秒为单位。</param>
        internal override void Update(float elapseSeconds, float realElapseSeconds)
        {
            foreach (var model in customizeModules)
            {
                model.OnUpdate(elapseSeconds,realElapseSeconds);
            }
        }

        /// <summary>
        /// 关闭并清理自定义模块管理器。
        /// </summary>
        internal override void Shutdown()
        {
            customizeModules.Clear();
        }

       
    }

}

