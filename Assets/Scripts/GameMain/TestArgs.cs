using GameFramework;
using GameFramework.Event;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestArgs : GameEventArgs
{
    public static readonly int EventId = typeof(TestArgs).GetHashCode();
    public override int Id
    {
        get
        {
            return EventId;
        }
    }

    public string NewText
    {
        get;
        private set;
    }

    public static TestArgs Create(string ChangeText)
    {
        // 使用引用池技术，避免频繁内存分配
        TestArgs e = ReferencePool.Acquire<TestArgs>();
        e.NewText = ChangeText;
        return e;
    }




    public override void Clear()
    {
        NewText = null;
    }


}
