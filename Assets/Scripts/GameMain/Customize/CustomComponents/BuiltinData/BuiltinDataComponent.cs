//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using GameFramework;
using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace GameName
{
    public class BuiltinDataComponent : GameFrameworkComponent
    {
        [SerializeField]
        private TextAsset m_BuildInfoTextAsset = null;

        //[SerializeField]
        //private TextAsset m_DefaultDictionaryTextAsset = null;


        private Dictionary<string, string> abHashInfo;

        private BuildInfo m_BuildInfo = null;

        public BuildInfo BuildInfo
        {
            get
            {
                return m_BuildInfo;
            }
        }
        public Dictionary<string,string> ABHashInfo
        {
            get
            {
                return abHashInfo;
            }
        }

       

        public void InitBuildInfo()
        {
            if (m_BuildInfoTextAsset == null || string.IsNullOrEmpty(m_BuildInfoTextAsset.text))
            {
                Log.Info("Build info can not be found or empty.");
                return;
            }

            m_BuildInfo = Utility.Json.ToObject<BuildInfo>(m_BuildInfoTextAsset.text);
            if (m_BuildInfo == null)
            {
                Log.Warning("Parse build info failure.");
                return;
            }
            
        }


        public void InitABHashInfoDictionary(string str)
        {
            abHashInfo = new Dictionary<string, string>();
            var jsdata = JsonMapper.ToObject(str);
            IDictionary temp = (IDictionary)jsdata;
            foreach (DictionaryEntry item in temp)
            {
                var abName = (string)item.Key;
                var hashjs =item.Value as JsonData;
                var jsStr = hashjs.ToJson();
                jsStr = jsStr.Trim('"');
                abHashInfo.Add(abName, jsStr);          
            }
        }
    }
}
