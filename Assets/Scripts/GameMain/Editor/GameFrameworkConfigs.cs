﻿//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using GameFramework;
using System.IO;
using UnityEngine;
using UnityGameFramework.Editor;
using UnityGameFramework.Editor.ResourceTools;

namespace GameName
{
    public static class GameFrameworkConfigs
    {
        [BuildSettingsConfigPath]
        public static string BuildSettingsConfig = Utility.Path.GetRegularPath(Path.Combine(Application.dataPath, "Res/Configs/BuildSettings.xml"));

        [ResourceCollectionConfigPath]
        public static string ResourceCollectionConfig = Utility.Path.GetRegularPath(Path.Combine(Application.dataPath, "Res/Configs/ResourceCollection.xml"));

        [ResourceEditorConfigPath]
        public static string ResourceEditorConfig = Utility.Path.GetRegularPath(Path.Combine(Application.dataPath, "Res/Configs/ResourceEditor.xml"));

        [ResourceBuilderConfigPath]
        public static string ResourceBuilderConfig = Utility.Path.GetRegularPath(Path.Combine(Application.dataPath, "Res/Configs/ResourceBuilder.xml"));
    }
}