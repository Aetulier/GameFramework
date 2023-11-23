//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using GameMain.SpriteCollection;
using GameMain.Timer;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace GameMain
{
    /// <summary>
    /// 游戏入口。
    /// </summary>
    public partial class GameEntry : MonoBehaviour
    {
        public static CustomizeComponent CustomizeComponent
        {
            get;
            private set;
        }

        public static BuiltinDataComponent BuiltinData
        {
            get;
            private set;
        }
        /// <summary>
        /// 获取相机组件。
        /// </summary>
        public static CameraComponent m_Camera
        {
            get;
            private set;
        }

        public static TimerComponent m_Timer
        {
            get;
            private set;
        }

        public static SpriteCollectionComponent m_SpriteCollection
        {
            get;
            private set;
        }

        private static void InitCustomComponents()
        {
            CustomizeComponent = UnityGameFramework.Runtime.GameEntry.GetComponent<CustomizeComponent>();
            BuiltinData = UnityGameFramework.Runtime.GameEntry.GetComponent<BuiltinDataComponent>();
            m_Camera = UnityGameFramework.Runtime.GameEntry.GetComponent<CameraComponent>();
            m_Timer = UnityGameFramework.Runtime.GameEntry.GetComponent<TimerComponent>();
            m_SpriteCollection= UnityGameFramework.Runtime.GameEntry.GetComponent<SpriteCollectionComponent>();
        }
    }
}
