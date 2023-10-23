//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using GameFramework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameName
{

    public sealed class VarIntArray : Variable<int[]>
    {
        public VarIntArray()
        {
        }

         internal List<int> ToList()
        {
            return Value.ToList();
        }

        public static implicit operator VarIntArray(int[] value)
        {
            VarIntArray varValue = ReferencePool.Acquire<VarIntArray>();
            varValue.Value = value;
            return varValue;
        }

        public static implicit operator int[](VarIntArray value)
        {
            return value.Value;
        }
    }
}
