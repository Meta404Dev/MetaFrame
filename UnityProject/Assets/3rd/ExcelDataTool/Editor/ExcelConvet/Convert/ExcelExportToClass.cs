using ExcelDataReader;
using System.Data;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace XFramework.ExcelData.Editor
{
    public class ExcelExportToClass
    {
        public void Generate(string filePath)
        {
            FileStream file = File.Open(filePath, FileMode.Open);

            using (IExcelDataReader excelData = ExcelReaderFactory.CreateOpenXmlReader(file))
            {
                DataSet dataSet = excelData.AsDataSet();
                DataTable sheet = dataSet.Tables[0];

                string tempName = Path.GetFileNameWithoutExtension(filePath);
                tempName = tempName.Replace("t_", "");
                string dataItemClassName = "ExcelDataItem" + tempName;
                string dataTableClassName = "ExcelDataTable" + tempName;

                ExcelMiddleData data = new ExcelMiddleData();
                data.Init(sheet, ExcelConvertPathSetting.EXCEL_START_ROW_INDEX);

                StringBuilder sbProps = new StringBuilder();
                for (int i = 0; i < data.columnCount; i++)
                {
                    var type = data.types[i];
                    var prop = data.props[i];
                    var note = data.notes[i];

                    if (prop == "id") continue;

                    sbProps.Append("\t/// <summary>\n");
                    sbProps.Append("\t/// " + note + "\n");
                    sbProps.Append("\t/// </summary>\n");
                    sbProps.Append(string.Format("\tpublic {0} {1};\n", type, prop));
                    sbProps.AppendLine();
                }

                StringBuilder sbInit = new StringBuilder();
                for (int i = 0; i < data.columnCount; i++)
                {
                    var type = data.types[i];
                    var prop = data.props[i];
                    var note = data.notes[i];

                    string initProp = prop;
                    string initValue = string.Format("data[\"{0}\"]", prop);
                    initValue = string.Format(GetConvertStr(type), initValue);
                    string initFinalString = string.Format("\t\t\t\t{0} = {1},\n", initProp, initValue);
                    sbInit.Append(initFinalString);
                }

                string tempStrFile = AssetDatabase.LoadAssetAtPath<TextAsset>(ExcelConvertPathSetting.ExcelTemplateFilePath).text;
                tempStrFile = tempStrFile.Replace("{0}", dataItemClassName);
                tempStrFile = tempStrFile.Replace("{1}", dataTableClassName);
                tempStrFile = tempStrFile.Replace("{2}", sbProps.ToString());
                tempStrFile = tempStrFile.Replace("{3}", sbInit.ToString());

                string targetFilePath = ExcelConvertPathSetting.GetExcelGenerateCSFilePath() + dataTableClassName + ".cs";

                if (File.Exists(targetFilePath))
                {
                    if (EditorUtility.DisplayDialog("警告", "检测到脚本，是否覆盖", "确定", "取消"))
                    {
                        SaveFile(tempStrFile, targetFilePath);
                    }
                }
                else
                {
                    SaveFile(tempStrFile, targetFilePath);
                }
            }
        }

        private void SaveFile(string str, string filePath)
        {
            if (File.Exists(filePath)) File.Delete(filePath);

            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    sw.Write(str);
                }
            }
            Debug.Log("class create: " + filePath);
            AssetDatabase.Refresh();
        }


        private string GetConvertStr(string type)
        {
            if (type == "int")
            {
                return "Convert.ToInt32({0})";
            }
            else if (type == "float")
            {
                return "Convert.ToSingle({0})";
            }
            else if (type == "bool")
            {
                return "Convert.ToBoolean({0})";
            }
            else
            {
                return "{0}";
            }
        }
    }
}