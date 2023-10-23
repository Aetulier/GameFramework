#if !ODIN_INSPECTOR
using System;
using UnityEngine;

namespace GameName
{
    [Serializable]
    public class StringSpriteDictionary : SerializableDictionary<string, Sprite> {}
}
#endif