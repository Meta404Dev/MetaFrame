using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace XFramework.ExcelData.Editor
{
    public class ExcelExportToAsset
    {
        public void Generate(string filePath)
        {
            FileStream file = File.Open(filePath, FileMode.Open);

            using (IExcelDataReader excelData = ExcelReaderFactory.CreateOpenXmlReader(file))
            {
                DataSet dataSet = excelData.AsDataSet();
                DataTable sheet = dataSet.Tables[0];

                ExcelMiddleData data = new ExcelMiddleData();
                data.Init(sheet, ExcelConvertPathSetting.EXCEL_START_ROW_INDEX);

                string tempName = Path.GetFileNameWithoutExtension(filePath);
                tempName = tempName.Replace("t_", "");

                string json = LitJson.JsonMapper.ToJson(data.excelMiddleDatas);

                string targetFilePath = ExcelConvertPathSetting.GetExcelGenerateAssetFilePath() + tempName + ".json";

                if (File.Exists(targetFilePath))
                {
                    if (EditorUtility.DisplayDialog("警告", "检测到Asset，是否覆盖", "确定", "取消"))
                    {
                        SaveFile(json, targetFilePath);
                    }
                }
                else
                {
                    SaveFile(json, targetFilePath);
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
            Debug.Log("asset create: " + filePath);
            AssetDatabase.Refresh();
        }



    }
}