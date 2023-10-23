//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using GameFramework;
using UnityEngine;

namespace GameName
{
    /// <summary>
    /// UnityEngine.Vector3Int 变量类。
    /// </summary>
    public sealed class VarVector3Int : Variable<Vector3Int>
    {
        /// <summary>
        /// 初始化 UnityEngine.Vector3Int 变量类的新实例。
        /// </summary>
        public VarVector3Int()
        {
        }

        /// <summary>
        /// 从 UnityEngine.Vector3Int 到 UnityEngine.Vector3Int 变量类的隐式转换。
        /// </summary>
        /// <param name="value">值。</param>
        public static implicit operator VarVector3Int(Vector3Int value)
        {
            VarVector3Int varValue = ReferencePool.Acquire<VarVector3Int>();
            varValue.Value = value;
            return varValue;
        }

        /// <summary>
        /// 从 UnityEngine.Vector3Int 变量类到 UnityEngine.Vector3Int 的隐式转换。
        /// </summary>
        /// <param name="value">值。</param>
        public static implicit operator Vector3Int(VarVector3Int value)
        {
            return value.Value;
        }
    }
}
