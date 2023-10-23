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
    /// UnityEngine.Vector3Int[] 变量类。
    /// </summary>
    public sealed class VarArrayVector3Int : Variable<Vector3Int[]>
    {
        /// <summary>
        /// 初始化 UnityEngine.Vector3Int[] 变量类的新实例。
        /// </summary>
        public VarArrayVector3Int()
        {
        }

        /// <summary>
        /// 从 UnityEngine.Vector3Int[] 到 UnityEngine.Vector3Int[] 变量类的隐式转换。
        /// </summary>
        /// <param name="value">值。</param>
        public static implicit operator VarArrayVector3Int(Vector3Int[] value)
        {
            VarArrayVector3Int varValue = ReferencePool.Acquire<VarArrayVector3Int>();
            varValue.Value = value;
            return varValue;
        }

        /// <summary>
        /// 从 UnityEngine.Vector3Int[] 变量类到 UnityEngine.Vector3Int[] 的隐式转换。
        /// </summary>
        /// <param name="value">值。</param>
        public static implicit operator Vector3Int[](VarArrayVector3Int value)
        {
            return value.Value;
        }
    }
}
