using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace XFramework.ExcelData.Editor
{
    public static class ExcelConvertPathSetting
    {
        /// <summary>
        /// 插件路径
        /// </summary>
        public const string PluginPath = "Assets/3rd/ExcelDataTool/";

        /// <summary>
        /// 模板路径
        /// </summary>
        public const string ExcelTemplateFilePath = PluginPath + "Editor/ExcelConvet/Template/ExcelDataClassTemplate.txt";

        /// <summary>
        /// 代码生成路径
        /// </summary>
        public const string GenerateCSFilePath = "/HotUpdateScripts/Game/ExcelData/";

        /// <summary>
        /// 二进制数据生成路径
        /// </summary>
        public const string ASSET_OUTPUT_PATH = "Assets/HotUpdateResources/ExcelData/";

        /// <summary>
        /// - type
        /// - name
        /// - note
        /// - ...
        /// 表从第4行开始，index从3开始
        /// </summary>
        public const int EXCEL_START_ROW_INDEX = 3;

        /// <summary>
        /// Excel表格路径
        /// </summary>
        /// <returns></returns>
        public static string GetExcelPath()
        {
            // path: ../../design/config/
            string excelPath = Application.dataPath.Replace("/UnityProject/Assets", "/design/config/");

            return excelPath;
        }

        /// <summary>
        /// 代码完整生成路径
        /// </summary>
        /// <returns></returns>
        public static string GetExcelGenerateCSFilePath()
        {
            string codeGeneratePath = Application.dataPath.Replace("/Assets", GenerateCSFilePath);
            return codeGeneratePath;
        }

        /// <summary>
        /// asset完整生成路径
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
