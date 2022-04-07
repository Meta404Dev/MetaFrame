using System;
using System.Collections.Generic;
using System.IO;

namespace XFramework.ExcelData.Editor
{
    public class ExcelConvertRequest
    {

        /// <summary>
        /// ����Excel��Ӧ��Class
        /// </summary>
        public void GenerateAllClass()
        {
            string[] excelPaths = GetAllFilesAtPath(ExcelConvertPathSetting.GetExcelPath(), ".xlsx");

            for (int i = 0; i < excelPaths.Length; i++)
            {
                new ExcelExportToClass().Generate(excelPaths[i]);
            }
        }


        /// <summary>
        /// ����Excel��Ӧ��Asset
        /// </summary>
        public void GenerateAllAsset()
        {
            string[] excelPaths = GetAllFilesAtPath(ExcelConvertPathSetting.GetExcelPath(), ".xlsx");

            for (int i = 0; i < excelPaths.Length; i++)
            {
                new ExcelExportToAsset().Generate(excelPaths[i]);
            }
        }



        private static string[] GetAllFilesAtPath(string path, string extension)
        {
            List<string> list = new List<string>();

            if (!Directory.Exists(path)) return null;

            foreach (string filePath in Directory.GetFiles(path))
            {
                if (Path.GetExtension(filePath) == extension)
                {
                    list.Add(filePath);
                }
            }

            return list.ToArray();
        }


    }
}