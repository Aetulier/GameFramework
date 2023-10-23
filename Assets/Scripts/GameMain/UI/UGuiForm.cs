using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime;

namespace GameName
{
    public abstract class UGuiForm : UIFormLogic
    {

        //public const int DepthFactor = 100;
        //private const float FadeTime = 0.3f;
        protected static TMP_FontAsset s_MainFont = null;
        //private Canvas m_CachedCanvas = null;
        //private CanvasGroup m_CanvasGroup = null;
        //private List<Canvas> m_CachedCanvasContainer = new List<Canvas>();

        //public int OriginalDepth
        //{
        //    get;
        //    private set;
        //}

        //public int Depth
        //{
        //    get
        //    {
        //        return m_CachedCanvas.sortingOrder;
        //    }
        //}

        public static void SetMainFont(TMP_FontAsset mainFont)
        {
            if (mainFont == null)
            {
                Log.Error("Main font is invalid.");
                return;
            }

            s_MainFont = mainFont;
        }
        public static TMP_FontAsset GetMainFont()
        {
            return s_MainFont;
        }

        protected override void OnInit(object userData)

        {
            base.OnInit(userData);

            //m_CachedCanvas = gameObject.GetOrAddComponent<Canvas>();
            //m_CachedCanvas.overrideSorting = true;
            //OriginalDepth = m_CachedCanvas.sortingOrder;

            //gameObject.GetOrAddComponent<GraphicRaycaster>();

            TMP_Text [] texts = GetComponentsInChildren<TMP_Text>(true);
            for (int i = 0; i < texts.Length; i++)
            {
                texts[i].font = s_MainFont;
                //if (!string.IsNullOrEmpty(texts[i].text))
                //{
                //    texts[i].text = GameEntry.Localization.GetString(texts[i].text);
                //}
            }
            //Button[] btns = GetComponentsInChildren<Button>(true);
            //for (int i = 0; i < btns.Length; i++)
            //{
              
                
            //}
        }

#if UNITY_EDITOR
        [ContextMenu("ClearTextFont")]
        public void ClearTextFontAsset()
        {
            TMP_Text[] texts = GetComponentsInChildren<TMP_Text>(true);
            var font_= Resources.Load<TMP_FontAsset>("Fonts & Materials/LiberationSans SDF - Fallback");
            for (int i = 0; i < texts.Length; i++)
            {
                texts[i].font = font_;
            }
        }
#endif
    }

}

