using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace XFramework.ExcelData.Editor
{
    public static class ExcelConvertPathSetting
    {
        /// <summary>
        /// ���·��
        /// </summary>
        public const string PluginPath = "Assets/3rd/ExcelDataTool/";

        /// <summary>
        /// ģ��·��
        /// </summary>
        public const string ExcelTemplateFilePath = PluginPath + "Editor/ExcelConvet/Template/ExcelDataClassTemplate.txt";

        /// <summary>
        /// ��������·��
        /// </summary>
        public const string GenerateCSFilePath = "/HotUpdateScripts/Game/ExcelData/";

        /// <summary>
        /// ��������������·��
        /// </summary>
        public const string ASSET_OUTPUT_PATH = "Assets/HotUpdateResources/ExcelData/";

        /// <summary>
        /// - type
        /// - name
        /// - note
        /// - ...
        /// ��ӵ�4�п�ʼ��index��3��ʼ
        /// </summary>
        public const int EXCEL_START_ROW_INDEX = 3;

        /// <summary>
        /// Excel���·��
        /// </summary>
        /// <returns></returns>
        public static string GetExcelPath()
        {
            // path: ../../design/config/
            string excelPath = Application.dataPath.Replace("/UnityProject/Assets", "/design/config/");

            return excelPath;
        }

        /// <summary>
        /// ������������·��
        /// </summary>
        /// <returns></returns>
        public static string GetExcelGenerateCSFilePath()
        {
            string codeGeneratePath = Application.dataPath.Replace("/Assets", GenerateCSFilePath);
            return codeGeneratePath;
        }

        /// <summary>
        /// asset��������·��
        /// </summary>
        /// <returns></returns>
        public static string GetExcelGenerateAssetFilePath()
        {
            string assetGeneratePath = Application.dataPath + ASSET_OUTPUT_PATH;
            assetGeneratePath = assetGeneratePath.Replace("/AssetsAssets", "/Assets");
            return assetGeneratePath;
        }
    }
}
