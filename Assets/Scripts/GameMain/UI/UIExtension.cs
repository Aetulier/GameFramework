//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using System.Collections;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace GameName
{
    public static class UIExtension
    {

        //public static int? OpenUIForm(this UIComponent uiComponent, string uiFormId, object userData = null)
        //{
        //    return uiComponent.OpenUIForm((int)uiFormId, userData);
        //}

        public static int OpenUIForm_Ex(this UIComponent uiComponent, string assetName, string uiGroupName, object userData = null)
        {

            if (uiComponent.IsLoadingUIForm(assetName))
            {
                  return -1;
            }

            if (uiComponent.HasUIForm(assetName))
            {

                  return -1;
            }
            
            return uiComponent.OpenUIForm(assetName, uiGroupName, userData);
        }




    }
}
