//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using GameFramework;
using UnityEngine;

namespace GameMain
{
    /// <summary>
    /// UnityEngine.Vector3[] 变量类。
    /// </summary>
    public sealed class VarArrayVector3 : Variable<Vector3[]>
    {
        /// <summary>
        /// 初始化 UnityEngine.Vector3[] 变量类的新实例。
        /// </summary>
        public VarArrayVector3()
        {
        }

        /// <summary>
        /// 从 UnityEngine.Vector3[] 到 UnityEngine.Vector3[] 变量类的隐式转换。
        /// </summary>
        /// <param name="value">值。</param>
        public static implicit operator VarArrayVector3(Vector3[] value)
        {
            VarArrayVector3 varValue = ReferencePool.Acquire<VarArrayVector3>();
            varValue.Value = value;
            return varValue;
        }

        /// <summary>
        /// 从 UnityEngine.Vector3[] 变量类到 UnityEngine.Vector3[] 的隐式转换。
        /// </summary>
        /// <param name="value">值。</param>
        public static implicit operator Vector3[](VarArrayVector3 value)
        {
            return value.Value;
        }
    }
}
