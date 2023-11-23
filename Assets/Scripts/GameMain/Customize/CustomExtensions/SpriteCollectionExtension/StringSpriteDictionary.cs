#if !ODIN_INSPECTOR
using System;
using UnityEngine;

namespace GameMain
{
    [Serializable]
    public class StringSpriteDictionary : SerializableDictionary<string, Sprite> {}
}
#endif