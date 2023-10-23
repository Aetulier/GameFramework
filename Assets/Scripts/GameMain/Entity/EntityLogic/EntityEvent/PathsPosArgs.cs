using GameFramework;
using GameFramework.Event;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathsPosArgs : GameEventArgs
{
    public static readonly int EventId = typeof(PathsPosArgs).GetHashCode();
    public override int Id
    {
        get
        {
            return EventId;
        }
    }

    public List<Vector3> PathPos
    {
        get;
        private set;
    }

    public static PathsPosArgs Create(List<Vector3> path_p)
    {
        // 使用引用池技术，避免频繁内存分配
        PathsPosArgs e = ReferencePool.Acquire<PathsPosArgs>();
        e.PathPos = path_p;
        return e;
    }

    public override void Clear()
    {
        PathPos.Clear();
    }


}
