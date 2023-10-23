using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using ExcelDataReader;
using System.IO;
using GameFramework;

namespace GameName.Editor.ConfigTools {

    public sealed class ConfigGenerator 
    {
        private const string ConfigsPath = "Assets/Res/Configs";

        [MenuItem("配置表工具/Generate Config")]
        private static void GenerateConfig() {            
            GeneratorByte();
        }

        static void GeneratorByte()
        {
            string configPath = Utility.Path.GetRegularPath(Path.Combine(ConfigsPath, "DefaultConfig.xlsx"));
            List<string> configStr = new List<string>();
            using (var stream = File.Open(configPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                var reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                var result = reader.AsDataSet();
                var tableOne = result.Tables[0];

                int rawRowCount = tableOne.Rows.Count;
                int rawColumnCount = tableOne.Columns.Count;
                for (int i = 0; i < tableOne.Rows.Count; i++)
                {
                    string[] rawValue = new string[tableOne.Columns.Count];
                    if (tableOne.Rows[i][0].ToString() != "#") {
                        configStr.Add(tableOne.Rows[i][1].ToString());
                        configStr.Add(tableOne.Rows[i][3].ToString());
                    }
                   
                }
                reader.Close();
            }
            string binaryDataFileName = Utility.Path.GetRegularPath(Path.Combine(ConfigsPath, "DefaultConfig.bytes"));
            if (File.Exists(binaryDataFileName))
            {
                File.Delete(binaryDataFileName);
            }

            using (FileStream fileStream = new FileStream(binaryDataFileName, FileMode.Create, FileAccess.Write))
            {
                using (BinaryWriter binaryWriter = new BinaryWriter(fileStream, System.Text.Encoding.UTF8))
                {
                    for (int i = 0; i < configStr.Count; i++)
                    {
                        binaryWriter.Write(configStr[i]);
                    }
                }
                
            }
            AssetDatabase.Refresh();
        }

    }

}

