//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using GameFramework;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using ExcelDataReader;
using System.IO;
using System.Linq;

namespace GameName.Editor.DataTableTools
{
    public sealed class DataTableGeneratorMenu
    {
        private const string DataTableExcelsPath = "Assets/Res/DataTableExcels";
        [MenuItem("配置表工具/Generate DataTables")]
        private static void GenerateDataTables()
        {
            HashSet<string> types = new HashSet<string>();
            string[] ExcelFilePaths = new string[0];
            List<System.Data.DataTable> tables = new();
            if (Directory.Exists(DataTableExcelsPath))
            {
                var excelFolder = new DirectoryInfo(DataTableExcelsPath);
                ExcelFilePaths = excelFolder.GetFiles("*.xlsx", SearchOption.TopDirectoryOnly)
                    .Where(_ => !_.Name.StartsWith("~$")).Select(_ => Utility.Path.GetRegularPath(_.FullName))
                    .ToArray();
            }
            foreach (var excelPath in ExcelFilePaths)
            {
                using (var stream = File.Open(excelPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    var reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                    var result = reader.AsDataSet();
                    foreach (System.Data.DataTable table in result.Tables)
                    {
                        tables.Add(table);
                    }
                    reader.Close();
                }
            }
            foreach (var dataTable in tables)
            {
                DataTableProcessor dataTableProcessor = DataTableGenerator.CreateDataTableProcessor(dataTable);
                var dataTableName = dataTable.TableName;
                foreach (var type in dataTableProcessor.GetTypes())
                {
                    types.Add(type);
                }
                if (!DataTableGenerator.CheckRawData(dataTableProcessor, dataTableName))
                {
                    Debug.LogError(Utility.Text.Format("Check raw data failure. DataTableName='{0}'", dataTableName));
                    break;
                }

                DataTableGenerator.GenerateDataFile(dataTableProcessor, dataTableName);
                DataTableGenerator.GenerateCodeFile(dataTableProcessor, dataTableName);
            }
            ExtensionsGenerate.GenerateExtensionByAnalysis(types);
            AssetDatabase.Refresh();
        }
    }
}
