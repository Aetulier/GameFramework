using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using GameFramework;
using System.Linq;
using UnityEditor;

namespace GameMain.Editor.DataTableTools
{
    public static class ExtensionsGenerate
    {
        private const string ExtensionDirectoryPath = "Assets/Scripts/GameMain/DataTable";
        public static void GenerateExtensionByAnalysis(HashSet<string> types_)
        {
            List<string> types = types_.ToList();            
            types = types.Distinct().ToList();

            types.Remove("Id");
            types.Remove("#");
            types.Remove("");
            types.Remove("comment");

            List<DataTableProcessor.DataProcessor> datableDataProcessors =
                 types.Select(DataTableProcessor.DataProcessorUtility.GetDataProcessor).ToList();

            NameSpaces.Add("System");
            NameSpaces.Add("System.IO");
            NameSpaces.Add("System.Collections.Generic");
            NameSpaces.Add("UnityEngine");
            NameSpaces = NameSpaces.Distinct().ToList();
            var dataProcessorsArray = datableDataProcessors
                .Where(_ => _.LanguageKeyword.ToLower().EndsWith("[]"))
                .Select(_ =>
                    DataTableProcessor.DataProcessorUtility.GetDataProcessor(_.LanguageKeyword.ToLower()
                        .Replace("[]", "")))
                .ToDictionary(_ => _.LanguageKeyword, _ => _);
             
            if (dataProcessorsArray.Count > 0)
            {
                GenerateDataTableExtensionArray(dataProcessorsArray);
                GenerateBinaryReaderExtensionArray(dataProcessorsArray);
            }
            
            //AssetDatabase.Refresh();
        }

        private static void GenerateDataTableExtensionArray(
            IDictionary<string, DataTableProcessor.DataProcessor> dataProcessors)
        {
            var sb = new StringBuilder();
            AddNameSpaces(sb);
            sb.AppendLine($"namespace GameMain");
            sb.AppendLine("{");
            sb.AppendLine("\tpublic static partial class DataTableExtension");
            sb.AppendLine("\t{");
            foreach (var item in dataProcessors)
            {
                sb.AppendLine($"\t\tpublic static {item.Key}[] Parse{item.Value.Type.Name}Array(string value)");

                sb.AppendLine("\t\t{");
                sb.AppendLine("\t\t\tif (string.IsNullOrEmpty(value) || value.ToLowerInvariant().Equals(\"null\"))");
                sb.AppendLine("\t\t\t\treturn null;");

                sb.AppendLine("\t\t\tstring[] splitValue = value.Split(',');");

                sb.AppendLine($"\t\t\t{item.Key}[] array = new {item.Key}[splitValue.Length];");

                sb.AppendLine("\t\t\tfor (int i = 0; i < splitValue.Length; i++)");
                sb.AppendLine("\t\t\t{");
                if (item.Value.IsSystem)
                {
                    if (item.Key == "string")
                        sb.AppendLine("\t\t\t\tarray[i] = splitValue[i];");
                    else
                        sb.AppendLine($"\t\t\t\tarray[i] = {item.Value.Type.Name}.Parse(splitValue[i]);");
                }
                else
                {
                    sb.AppendLine($"\t\t\t\tarray[i] = Parse{item.Value.Type.Name}(splitValue[i]);");
                }

                sb.AppendLine("\t\t\t}");
                sb.AppendLine();
                sb.AppendLine("\t\t\treturn array;");
                sb.AppendLine("\t\t}");
            }

            sb.AppendLine("\t}");
            sb.AppendLine("}");
            GenerateCodeFile("DataTableExtension.Array", sb.ToString());
        }
        private static void GenerateBinaryReaderExtensionArray(
            IDictionary<string, DataTableProcessor.DataProcessor> dataProcessors)
        {
            var sb = new StringBuilder();
            AddNameSpaces(sb);

            sb.AppendLine($"namespace GameMain");
            sb.AppendLine("{");
            sb.AppendLine("\tpublic static partial class BinaryReaderExtension");
            sb.AppendLine("\t{");
            foreach (var item in dataProcessors)
            {
                sb.AppendLine(
                        $"\t\tpublic static {item.Key}[] Read{item.Value.Type.Name}Array(this BinaryReader binaryReader)");


                sb.AppendLine("\t\t{");
                sb.AppendLine("\t\t\tint count = binaryReader.Read7BitEncodedInt32();");
                sb.AppendLine($"\t\t\t{item.Key}[] array = new {item.Key}[count];");


                sb.AppendLine("\t\t\tfor (int i = 0; i < count; i++)");
                sb.AppendLine("\t\t\t{");

                var languageKeyword = item.Key;
                if (languageKeyword == "int" || languageKeyword == "uint" || languageKeyword == "long" ||
                    languageKeyword == "ulong")
                    sb.AppendLine($"\t\t\t\tarray[i] = binaryReader.Read7BitEncoded{item.Value.Type.Name}();");
                else
                    sb.AppendLine($"\t\t\t\tarray[i] = binaryReader.Read{item.Value.Type.Name}();");

                sb.AppendLine("\t\t\t}");
                sb.AppendLine("\t\t\treturn array;");
                sb.AppendLine("\t\t}");
            }

            sb.AppendLine("\t}");
            sb.AppendLine("}");
            GenerateCodeFile("BinaryReaderExtension.Array", sb.ToString());
        }


        private static void GenerateCodeFile(string fileName, string value)
        {
            var filePath =
                Utility.Path.GetRegularPath(Path.Combine(ExtensionDirectoryPath, fileName + ".cs"));
            if (File.Exists(filePath)) File.Delete(filePath);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                using (var stream = new StreamWriter(fileStream, Encoding.UTF8))
                {
                    stream.Write(value);
                }
            }
        }
        private static List<string> NameSpaces = new List<string>();
        private static void AddNameSpaces(StringBuilder stringBuilder)
        {
            foreach (var nameSpace in NameSpaces)
            {
                stringBuilder.AppendLine($"using {nameSpace};");
            }
        }

    }
}


