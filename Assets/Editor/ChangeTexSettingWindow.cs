using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class ChangeTexSettingWindow : EditorWindow
{

    enum TargetPlatform
    {
        Standalone,
        IOS,
        Android
    }
    [MenuItem("Tools/ChangeTexSettingsWindow")]
    public static void OpenChangeTexSettingsWindow()
    {
        ChangeTexSettingWindow window = EditorWindow.CreateInstance<ChangeTexSettingWindow>();
        window.Show();
    }
    string TexPath;
    string TexSuffix = "*.bmp|*.jpg|*.gif|*.png|*.tif|*.psd";
    private void OnGUI()
    {
        GUILayout.BeginHorizontal();
        TexPath = EditorGUILayout.TextField("图片资源路径", TexPath);
        if (GUILayout.Button(EditorGUIUtility.IconContent("Folder Icon"), GUILayout.Width(18), GUILayout.Height(18)))
        {
            TexPath = EditorUtility.OpenFolderPanel("图片路径选择", "", "");
        }
        GUILayout.EndHorizontal();
        GUI.enabled = false;
        GUILayout.BeginHorizontal();
       
        if (GUILayout.Button("转换"))
        {
            if (string.IsNullOrEmpty(TexPath) || !Directory.Exists(TexPath))
            {
                EditorUtility.DisplayDialog("错误", "路径不能为空或路径不存在", "确定");
                return;
            }
            if (string.IsNullOrEmpty(TexSuffix))
            {
                EditorUtility.DisplayDialog("错误", "路径不能为空或路径不存在", "确定");
                return;
            }
            List<string> lst = GetAllTexPaths(TexPath);
            int i = 0;
            for (; i < lst.Count; i++)
            {
                Change(lst[i]);      
            }
            AssetDatabase.SaveAssets();
            EditorUtility.ClearProgressBar();
        }
        GUILayout.EndHorizontal();
    }
    private void Change(string path)
    {
        path = path.Substring(path.IndexOf("Assets"));
        try
        {
            TextureImporter textureImporter = AssetImporter.GetAtPath(path) as TextureImporter;
            textureImporter.textureCompression = TextureImporterCompression.Uncompressed;
            textureImporter.SaveAndReimport();
            AssetDatabase.ImportAsset(path);
        }
        catch
        {
            AssetDatabase.SaveAssets();
            EditorUtility.ClearProgressBar();
        }
    }


    private List<string> GetAllTexPaths(string rootPath)
    {
        List<string> lst = new List<string>();
        string[] types = TexSuffix.Split('|');
        for (int i = 0; i < types.Length; i++)
        {
            lst.AddRange(Directory.GetFiles(rootPath, types[i], SearchOption.AllDirectories));
        }
        return lst;
    }
}