using GameFramework;

namespace GameMain
{
    public static class AssetUtility
    {
        public static string GetConfigAsset(string assetName, bool fromBytes)
        {
            return Utility.Text.Format("Assets/Res/Configs/{0}.{1}", assetName, fromBytes ? "bytes" : "txt");
        }

        public static string GetDataTableAsset(string assetName, bool fromBytes)
        {
            return Utility.Text.Format("Assets/Res/DataTables/{0}.{1}", assetName, fromBytes ? "bytes" : "txt");
        }

        public static string GetDictionaryAsset(string assetName, bool fromBytes)
        {
            return Utility.Text.Format("Assets/GameMain/Localization/{0}/Dictionaries/{1}.{2}", GameEntry.Localization.Language.ToString(), assetName, fromBytes ? "bytes" : "xml");
        }

        public static string GetTMPFontAsset(string assetName)
        {
            return Utility.Text.Format("Assets/Res/Fonts/{0}.asset", assetName);
        }
        public static string GetFontAsset(string assetName)
        {
            return Utility.Text.Format("Assets/Res/Fonts/{0}.otf", assetName);
        }

        public static string GetSceneAsset(string assetName)
        {
            return Utility.Text.Format("Assets/Res/Scenes/{0}.unity", assetName);
        }

        public static string GetMusicAsset(string assetName)
        {
            return Utility.Text.Format("Assets/GameMain/Music/{0}.mp3", assetName);
        }

        public static string GetSoundAsset(string assetName)
        {
            return Utility.Text.Format("Assets/Res/Sounds/{0}.mp3", assetName);
        }
        public static string GetEntityAsset(string assetName)
        {
            return Utility.Text.Format("Assets/Res/Prefabs/{0}.prefab", assetName);
        }

        public static string GetShaderAsset(string assetName)
        {
            return Utility.Text.Format("Assets/Res/Shaders/{0}.shader", assetName);
        }
        public static string GetMaterialAsset(string assetName)
        {
            return Utility.Text.Format("Assets/Res/Materials/{0}.mat", assetName);
        }

        public static string GetUIAsset(string assetName)
        {
            return Utility.Text.Format("Assets/Res/Prefabs/UI/{0}.prefab", assetName);
        }
        public static string GetSpriteAsset(string assetName)
        {
            return Utility.Text.Format("Assets/Res/Sprite/{0}.png", assetName);
        }

        public static string GetSpriteCollectionAsset(string assetName)
        {
            return Utility.Text.Format("Assets/Res/Sprite/{0}.asset", assetName);
        }
        public static string GetUISoundAsset(string assetName)
        {
            return Utility.Text.Format("Assets/GameMain/Sound/{0}.mp3", assetName);
        }

        public static string GetHotfixDLLAsset(string assetName)
        {
            return Utility.Text.Format("Assets/Res/HotfixDLL/{0}.bytes", assetName);
        }
        public static string GetLuaAsset(string assetName)
        {
            return Utility.Text.Format("Assets/Res/Lua/{0}.lua", assetName);
        }
    }
}
